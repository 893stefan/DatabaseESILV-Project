using Npgsql;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;

namespace SalleSportApp.Data
{
    public class CoursDAO
    {
        private readonly Database db = new Database();

        public List<Cours> GetCours()
        {
            List<Cours> cours = new List<Cours>();
            string query = "SELECT CoursID, NomCours, Description, Duree, Intensite, NiveauDifficulte, CapaciteMax FROM Cours ORDER BY NomCours";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                conn.Open();
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cours.Add(new Cours
                        {
                            CoursID = reader.GetInt32(0),
                            NomCours = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Duree = reader.GetInt32(3),
                            Intensite = reader.IsDBNull(4) ? null : reader.GetString(4),
                            NiveauDifficulte = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                            CapaciteMax = reader.GetInt32(6)
                        });
                    }
                }
            }

            return cours;
        }

        public bool AjouterCours(Cours cours)
        {
            string query = "INSERT INTO Cours (NomCours, Description, Duree, Intensite, NiveauDifficulte, CapaciteMax) " +
                           "VALUES (@Nom, @Description, @Duree, @Intensite, @Niveau, @Capacite)";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", cours.NomCours);
                cmd.Parameters.AddWithValue("@Description", (object)(cours.Description ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Duree", cours.Duree);
                cmd.Parameters.AddWithValue("@Intensite", (object)(cours.Intensite ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Niveau", cours.NiveauDifficulte);
                cmd.Parameters.AddWithValue("@Capacite", cours.CapaciteMax);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SupprimerCours(int coursId)
        {
            string query = "DELETE FROM Cours WHERE CoursID = @ID";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", coursId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
