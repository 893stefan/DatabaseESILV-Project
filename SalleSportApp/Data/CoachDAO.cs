using Npgsql;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;

namespace SalleSportApp.Data
{
    public class CoachDAO
    {
        private readonly Database db = new Database();

        public List<Coach> GetCoachs()
        {
            List<Coach> coachs = new List<Coach>();
            string query = "SELECT CoachID, Nom, Prenom, Specialite, Telephone, Email, Formation, Description FROM Coach ORDER BY Nom, Prenom";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                conn.Open();
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coachs.Add(new Coach
                        {
                            CoachID = reader.GetInt32(0),
                            Nom = reader.GetString(1),
                            Prenom = reader.GetString(2),
                            Specialite = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Telephone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Formation = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Description = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }

            return coachs;
        }

        public bool AjouterCoach(Coach coach)
        {
            string query = "INSERT INTO Coach (Nom, Prenom, Specialite, Telephone, Email, Formation, Description) " +
                           "VALUES (@Nom, @Prenom, @Specialite, @Telephone, @Email, @Formation, @Description)";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", coach.Nom);
                cmd.Parameters.AddWithValue("@Prenom", coach.Prenom);
                cmd.Parameters.AddWithValue("@Specialite", (object)(coach.Specialite ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Telephone", (object)(coach.Telephone ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Email", (object)(coach.Email ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Formation", (object)(coach.Formation ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@Description", (object)(coach.Description ?? DBNull.Value));

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SupprimerCoach(int coachId)
        {
            string query = "DELETE FROM Coach WHERE CoachID = @ID";

            using (NpgsqlConnection conn = db.CreateConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", coachId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
