using Npgsql;
using SalleSportApp.Forms;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Data;

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
            string query = "SELECT AdminID, Nom, Prenom, MotDePasseHash, NiveauPrivilege FROM Administrateur WHERE Email = @Email";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString(3);
                            string inputHash = HashPassword(motDePasseClair);

                            if (storedHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase))
                            {
                                return new Administrateur
                                {
                                    AdminID = reader.GetInt32(0),
                                    Nom = reader.GetString(1),
                                    Prenom = reader.GetString(2),
                                    NiveauPrivilege = reader.GetString(4) // 'Principal' ou 'Secondaire'
                                };
                            }
                        }
                    }
                }
            }
            return null; // Connexion échouée
        }

        // --- Opération Admin : Obtenir les membres en attente ---
        public List<Membre> GetMembresEnAttente()
        {
            List<Membre> membres = new List<Membre>();
            string query = "SELECT MembreID, Nom, Prenom, Email, DateInscription FROM Membre WHERE StatutAdhesion = 'En Attente' ORDER BY DateInscription ASC";

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
                                MembreID = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                Email = reader.GetString(3),
                                DateInscription = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return membres;
        }

        public List<string> GetRapportResume()
        {
            List<string> lignes = new List<string>();
            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                lignes.Add($"Membres total : {ExecuteCount(conn, "SELECT COUNT(*) FROM Membre")}");
                lignes.Add($"Membres en attente : {ExecuteCount(conn, "SELECT COUNT(*) FROM Membre WHERE StatutAdhesion = 'En Attente'")}");
                lignes.Add($"Coachs total : {ExecuteCount(conn, "SELECT COUNT(*) FROM Coach")}");
                lignes.Add($"Cours total : {ExecuteCount(conn, "SELECT COUNT(*) FROM Cours")}");
                lignes.Add($"Sessions total : {ExecuteCount(conn, "SELECT COUNT(*) FROM SessionCours")}");
                lignes.Add($"Reservations totales : {ExecuteCount(conn, "SELECT COUNT(*) FROM Reservation")}");
            }

            return lignes;
        }

        private int ExecuteCount(NpgsqlConnection conn, string query)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(result);
            }
        }

        // NOTE : Les méthodes de gestion des Coachs et des Cours iront aussi dans l'AdminDAO (ou dans des DAOs spécifiques comme CoachDAO/CoursDAO, mais pour le squelette, AdminDAO peut tout gérer).
    }
}
