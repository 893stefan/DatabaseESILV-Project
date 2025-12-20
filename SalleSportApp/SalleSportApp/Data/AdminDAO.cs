using Npgsql;
using SalleSportApp.Forms;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SalleSportApp.Data
{
    public class AdminDAO
    {
        private readonly Database db = new Database();

        // --- Méthode Utile : Simulation de Hashing (identique à celle du MembreDAO) ---
        private string HashPassword(string password)
        {
            // (La même méthode de hachage que dans MembreDAO.cs)
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // --- Opération Admin : Vérification de Connexion et Niveau de Privilège ---
        public Administrateur VerifierCredentials(string email, string motDePasseClair)
        {
            string query = "SELECT id, email, mot_de_passe_hash, role FROM utilisateur WHERE email = @Email";

            using (var conn = db.CreateConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString(reader.GetOrdinal("mot_de_passe_hash"));
                            string role = reader.GetString(reader.GetOrdinal("role"));

                            // Comparaison hash mot de passe
                            if (storedHash.Equals(HashPassword(motDePasseClair), StringComparison.OrdinalIgnoreCase))
                            {
                                // Retourne Administrateur si role correct
                                if (role == "admin_principal" || role == "admin_secondaire")
                                {
                                    return new Administrateur
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                                        Email = reader.GetString(reader.GetOrdinal("email")),
                                        Role = role
                                    };
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        // --- Opération Admin : Obtenir les membres en attente ---
        public List<Membre> GetMembresEnAttente()
        {
            List<Membre> membres = new List<Membre>();
            string query = @"
        SELECT u.id AS userId, m.nom, m.prenom, u.email, m.date_inscription
        FROM utilisateur u
        JOIN membre m ON m.fk_utilisateur_id = u.id
        WHERE m.statut_inscription = 'en_attente'
        ORDER BY m.date_inscription ASC;
    ";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    conn.Open();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            membres.Add(new Membre
                            {
                                id = reader.GetInt32(reader.GetOrdinal("userId")), // 🔹 ID utilisateur
                                Nom = reader.GetString(reader.GetOrdinal("nom")),
                                Prenom = reader.GetString(reader.GetOrdinal("prenom")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                DateInscription = reader.GetDateTime(reader.GetOrdinal("date_inscription"))
                            });
                        }
                    }
                }
            }
            return membres;
        }

        // NOTE : Les méthodes de gestion des Coachs et des Cours iront aussi dans l'AdminDAO (ou dans des DAOs spécifiques comme CoachDAO/CoursDAO, mais pour le squelette, AdminDAO peut tout gérer).
    }
}