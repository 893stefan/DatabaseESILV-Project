using Npgsql;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalleSportApp.Data
{
    public class CoursDAO
    {
        private readonly Database db = new Database();

        // Récupère les cours disponibles
        public enum IntensiteEnum { faible, moyenne, elevee }
        public enum NiveauDifficulteEnum { debutant, intermediaire, avance }

        public List<Cours> GetCoursDisponibles()
        {
            List<Cours> listeCours = new List<Cours>();
            string query = @"
        SELECT 
            id, nom, description, duree_min, intensite, niveau_difficulte, 
            capacite_max, horaire, coach_id, salle_id
        FROM cours
        ORDER BY horaire ASC;
    ";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Récupération des enums PostgreSQL comme string
                        string intensiteStr = reader.GetString(reader.GetOrdinal("intensite"));
                        string niveauStr = reader.GetString(reader.GetOrdinal("niveau_difficulte"));

                        // Mapping vers les enums C#
                        IntensiteEnum intensiteEnum = (IntensiteEnum)Enum.Parse(typeof(IntensiteEnum), intensiteStr, true);
                        NiveauDifficulteEnum niveauEnum = (NiveauDifficulteEnum)Enum.Parse(typeof(NiveauDifficulteEnum), niveauStr, true);

                        listeCours.Add(new Cours
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nom = reader.GetString(reader.GetOrdinal("nom")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            Duree = reader.GetInt32(reader.GetOrdinal("duree_min")),
                            Intensite = intensiteEnum,
                            NiveauDifficulte = niveauEnum,
                            CapaciteMax = reader.GetInt32(reader.GetOrdinal("capacite_max")),
                            Horaire = reader.GetDateTime(reader.GetOrdinal("horaire")),
                            CoachId = reader.GetInt32(reader.GetOrdinal("coach_id")),
                            SalleId = reader.GetInt32(reader.GetOrdinal("salle_id"))
                        });
                    }
                }
            }

            return listeCours;
        }

        // Réserver un cours
        public bool ReserverCours(int membreId, int coursId)
        {
            try
            {
                // Vérifier que le membre existe
                if (!MembreExiste(membreId))
                {
                    Console.WriteLine($"Erreur : Le membre avec ID {membreId} n'existe pas.");
                    return false;
                }

                // Vérifier que le cours existe
                if (!CoursExiste(coursId))
                {
                    Console.WriteLine($"Erreur : Le cours avec ID {coursId} n'existe pas.");
                    return false;
                }

                // Vérifier qu'il reste des places
                int placesDispo = GetPlacesDisponibles(coursId);
                if (placesDispo <= 0)
                {
                    Console.WriteLine("Erreur : Le cours est complet.");
                    return false;
                }

                string query = @"
            INSERT INTO inscription_cours (membre_id, cours_id, date_inscription)
            VALUES (@MembreId, @CoursId, NOW());
            
            UPDATE cours
            SET capacite_max = capacite_max - 1
            WHERE id = @CoursId AND capacite_max > 0;
        ";

                using (NpgsqlConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MembreId", membreId);
                        cmd.Parameters.AddWithValue("@CoursId", coursId);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la réservation : {ex.Message}");
                return false;
            }
        }

        // Méthodes auxiliaires adaptées à C# 7.3
        private bool MembreExiste(int membreId)
        {
            string query = "SELECT COUNT(*) FROM membre WHERE id = @id";
            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", membreId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private bool CoursExiste(int coursId)
        {
            string query = "SELECT COUNT(*) FROM cours WHERE id = @id";
            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", coursId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private int GetPlacesDisponibles(int coursId)
        {
            string query = "SELECT capacite_max FROM cours WHERE id = @id";
            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", coursId);
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public bool Ajouter(Cours c)
        {
            string query = @"
                INSERT INTO cours (nom, capacite_max, horaire, coach_id)
                VALUES (@Nom, @CapaciteMax, @Horaire, @CoachId);";

            NpgsqlConnection conn = db.CreateConnection();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@CapaciteMax", c.CapaciteMax);
                cmd.Parameters.AddWithValue("@Horaire", c.Horaire);
                cmd.Parameters.AddWithValue("@CoachId", c.CoachId);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout cours : " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // Modifier un cours
        public bool Modifier(Cours c)
        {
            string query = @"
                UPDATE cours
                SET nom=@Nom, capacite_max=@CapaciteMax, horaire=@Horaire, coach_id=@CoachId
                WHERE id=@Id;";

            NpgsqlConnection conn = db.CreateConnection();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", c.Id);
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@CapaciteMax", c.CapaciteMax);
                cmd.Parameters.AddWithValue("@Horaire", c.Horaire);
                cmd.Parameters.AddWithValue("@CoachId", c.CoachId);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification cours : " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Supprimer(int id)
        {
            string query = "DELETE FROM cours WHERE id=@Id;";
            NpgsqlConnection conn = db.CreateConnection();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (PostgresException pgEx)
            {
                if (pgEx.SqlState == "23503")
                    MessageBox.Show("Impossible de supprimer ce cours car il est associé à des inscriptions ou à un coach.");
                else
                    MessageBox.Show("Erreur suppression cours : " + pgEx.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

    }

}