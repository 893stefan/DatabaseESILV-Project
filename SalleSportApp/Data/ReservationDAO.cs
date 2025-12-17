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
        /// Tente de créer une réservation pour un membre sur une session de cours donnée.
        /// Inclut la vérification de la capacité maximale du cours.
        /// </summary>
        /// <param name="membreID">ID du membre qui réserve.</param>
        /// <param name="sessionID">ID de la session de cours.</param>
        /// <returns>True si la réservation a été créée, False sinon.</returns>
        public bool ReserverCours(int membreID, int sessionID)
        {
            try
            {
                // Étape 1 : Vérification de la capacité restante
                int capaciteRestante = GetCapaciteRestante(sessionID);

                if (capaciteRestante <= 0)
                {
                    Console.WriteLine("Erreur : La capacité maximale du cours est atteinte.");
                    return false;
                }

                // Étape 2 : Création de la réservation
                string insertQuery = "INSERT INTO Reservation (MembreID, SessionID, DateReservation, StatutReservation) " +
                                     "VALUES (@MembreID, @SessionID, NOW(), 'Confirmée')";

                using (NpgsqlConnection conn = db.CreateConnection())
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MembreID", membreID);
                        cmd.Parameters.AddWithValue("@SessionID", sessionID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la réservation : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Annule une réservation existante.
        /// </summary>
        public bool AnnulerReservation(int reservationID, int membreID)
        {
            // Vérifier que le membre est bien le propriétaire de la réservation pour la sécurité
            string updateQuery = "UPDATE Reservation SET StatutReservation = 'Annulée' " +
                                 "WHERE ReservationID = @ResID AND MembreID = @MemID AND StatutReservation = 'Confirmée'";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ResID", reservationID);
                    cmd.Parameters.AddWithValue("@MemID", membreID);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // --- Méthode de vérification de capacité (UTILISE UNE SOUS-REQUÊTE IMPLICITE) ---
        private int GetCapaciteRestante(int sessionID)
        {
            // Requête qui trouve la capacité max du Cours associé et soustrait le nombre de réservations confirmées.
            string query =
                // Requête avec jointure pour accéder à la capacité du cours (à détailler dans le SQL récapitulatif)
                "SELECT C.CapaciteMax - (SELECT COUNT(*) FROM Reservation R WHERE R.SessionID = S.SessionID AND R.StatutReservation = 'Confirmée') " +
                "FROM SessionCours S " +
                "JOIN Cours C ON S.CoursID = C.CoursID " +
                "WHERE S.SessionID = @SessionID";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SessionID", sessionID);

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Exécute une requête qui ne retourne qu'une seule valeur

                    if (result != null && result != DBNull.Value)
                    {
                        // Le résultat est un entier : la capacité restante
                        return Convert.ToInt32(result);
                    }
                    return 0; // Session non trouvée ou erreur
                }
            }
        }
    }
}