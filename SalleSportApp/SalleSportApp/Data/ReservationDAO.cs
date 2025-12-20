using System;
using Npgsql;
using System.Collections.Generic;
using SalleSportApp.Models; // Assurez-vous d'importer vos classes Models

namespace SalleSportApp.Data
{
    public class ReservationDAO
    {
        private readonly Database db = new Database();

        /// <summary>
        /// Crée une réservation pour un membre sur un cours donné.
        /// Vérifie la capacité maximale avant l'insertion.
        /// </summary>
        public bool ReserverCours(int membreId, int coursId)
        {
            try
            {
                using (var conn = db.CreateConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // 1️⃣ Vérifie que le membre existe et est valide
                        string checkMembreSql = "SELECT statut_inscription FROM membre WHERE id = @MembreId";
                        using (var cmd = new NpgsqlCommand(checkMembreSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MembreId", membreId);
                            var statut = cmd.ExecuteScalar() as string;

                            if (statut == null)
                            {
                                Console.WriteLine($"Erreur : Le membre avec ID {membreId} n'existe pas.");
                                transaction.Rollback();
                                return false;
                            }

                            if (statut != "valide")
                            {
                                Console.WriteLine($"Erreur : Le membre avec ID {membreId} n'est pas validé.");
                                transaction.Rollback();
                                return false;
                            }
                        }

                        // 2️⃣ Vérifie que le cours existe et récupère la capacité max
                        string checkCoursSql = @"
                    SELECT capacite_max, 
                           (SELECT COUNT(*) FROM inscription_cours ic WHERE ic.cours_id = c.id) AS inscrits
                    FROM cours c
                    WHERE id = @CoursId
                    FOR UPDATE"; // verrouille la ligne pour éviter surbooking
                        int capaciteMax = 0;
                        int inscrits = 0;
                        using (var cmd = new NpgsqlCommand(checkCoursSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CoursId", coursId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    Console.WriteLine($"Erreur : Le cours avec ID {coursId} n'existe pas.");
                                    transaction.Rollback();
                                    return false;
                                }
                                capaciteMax = reader.GetInt32(0);
                                inscrits = reader.GetInt32(1);
                            }
                        }

                        if (inscrits >= capaciteMax)
                        {
                            Console.WriteLine("Erreur : Le cours est complet.");
                            transaction.Rollback();
                            return false;
                        }

                        // 3️⃣ Insère la réservation
                        string insertSql = @"
                    INSERT INTO inscription_cours (membre_id, cours_id, date_inscription, statut)
                    VALUES (@MembreId, @CoursId, NOW(), 'Confirmée')";
                        using (var cmd = new NpgsqlCommand(insertSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MembreId", membreId);
                            cmd.Parameters.AddWithValue("@CoursId", coursId);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows == 0)
                            {
                                Console.WriteLine("Erreur : impossible de créer l'inscription.");
                                transaction.Rollback();
                                return false;
                            }
                        }

                        transaction.Commit();
                        Console.WriteLine("Réservation effectuée avec succès !");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la réservation : " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Annule une réservation existante.
        /// </summary>
        public bool AnnulerReservation(int reservationId, int membreId)
        {
            string query = @"
                DELETE FROM inscription_cours
                WHERE id = @id AND membre_id = @membreId
            ";

            using (var conn = db.CreateConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);
                cmd.Parameters.AddWithValue("@membreId", membreId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Récupère toutes les réservations d'un membre.
        /// </summary>
        public List<Reservation> GetReservationsByMembre(int membreId)
        {
            List<Reservation> reservations = new List<Reservation>();

            string query = @"
                SELECT 
                    r.id,
                    c.nom AS cours,
                    r.date_inscription
                FROM inscription_cours r
                JOIN cours c ON c.id = r.cours_id
                WHERE r.membre_id = @membreId
                ORDER BY r.date_inscription DESC;
            ";

            using (var conn = db.CreateConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@membreId", membreId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            Id = reader.GetInt32(0),
                            NomCours = reader.GetString(1),
                            DateReservation = reader.GetDateTime(2)
                        });
                    }
                }
            }

            return reservations;
        }

        /// <summary>
        /// Vérifie la capacité restante d'un cours.
        /// </summary>
        private int GetCapaciteRestante(int coursID)
        {
            string query = @"
                SELECT c.capacite_max - (
                    SELECT COUNT(*) 
                    FROM inscription_cours ic
                    WHERE ic.cours_id = @CoursID AND ic.statut = 'confirmée'
                )
                FROM cours c
                WHERE c.id = @CoursID;
            ";

            using (var conn = db.CreateConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CoursID", coursID);
                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);

                return 0; // Cours non trouvé
            }
        }
    }
}
