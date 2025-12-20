using Npgsql;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SalleSportApp.Data
{
    public class CoachDAO
    {
        private readonly Database db = new Database();

        public List<Coach> GetAll()
        {
            var liste = new List<Coach>();

            string query = @"
                SELECT id, nom, prenom, specialite, telephone, email
                FROM coach
                ORDER BY nom;
            ";

            using (var conn = db.CreateConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Coach
                        {
                            Id = reader.GetInt32(0),
                            Nom = reader.GetString(1),
                            Prenom = reader.GetString(2),
                            Specialite = reader.GetString(3),
                            Telephone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Email = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }
                }
            }
            return liste;
        }

        public bool Ajouter(Coach c)
        {
            string query = @"
        INSERT INTO coach
        (nom, prenom, specialite, telephone, email, formations, certifications, date_embauche)
        VALUES
        (@Nom, @Prenom, @Specialite, @Telephone, @Email, @Formations, @Certifications, @DateEmbauche);
    ";

            using (var conn = db.CreateConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@Prenom", c.Prenom);
                cmd.Parameters.AddWithValue("@Specialite", c.Specialite);
                cmd.Parameters.AddWithValue("@Telephone", (object)c.Telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)c.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Formations", (object)c.Formations ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Certifications", (object)c.Certifications ?? DBNull.Value);

                // ✅ DATE OBLIGATOIRE
                cmd.Parameters.AddWithValue("@DateEmbauche", DateTime.Now);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modifier(Coach c)
        {
            string query = @"
                UPDATE coach
                SET nom = @Nom,
                    prenom = @Prenom,
                    specialite = @Specialite,
                    telephone = @Telephone,
                    email = @Email
                WHERE id = @Id;
            ";

            using (var conn = db.CreateConnection())
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", c.Id);
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@Prenom", c.Prenom);
                cmd.Parameters.AddWithValue("@Specialite", c.Specialite);
                cmd.Parameters.AddWithValue("@Telephone", (object)c.Telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)c.Email ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Supprimer(int id)
        {
            string query = "DELETE FROM coach WHERE id = @Id;";

            NpgsqlConnection conn = db.CreateConnection();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (PostgresException pgEx)
            {
                if (pgEx.SqlState == "23503") // violation FK
                {
                    MessageBox.Show("Impossible de supprimer ce coach car il est associé à des cours.");
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression : " + pgEx.Message);
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
