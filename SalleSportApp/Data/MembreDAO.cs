using System;
using Npgsql;
using SalleSportApp.Models;
using System.Security.Cryptography; // Nécessaire pour simuler le hachage
using System.Text;

namespace SalleSportApp.Data
{
    public class MembreDAO
    {
        private readonly Database db = new Database();

        // --- Méthode Utile : Simulation de Hashing (à remplacer par BCrypt/PBKDF2 en production) ---
        private string HashPassword(string password)
        {
            // ATTENTION : Ceci est une simple simulation pour le squelette ! 
            // N'utilisez JAMAIS un simple SHA256 pour les mots de passe réels.
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

        // --- Opération Membre : Inscription (statut 'En Attente') ---
        public bool AjouterMembre(Membre nouveauMembre, string motDePasseClair)
        {
            // Le mot de passe DOIT être haché avant l'insertion dans la BDD
            string hashedPassword = HashPassword(motDePasseClair);

            string query = "INSERT INTO Membre (Nom, Prenom, Adresse, Telephone, Email, MotDePasseHash, DateInscription, StatutAdhesion) " +
                           "VALUES (@Nom, @Prenom, @Adresse, @Tel, @Email, @MdpHash, NOW(), 'En Attente')";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", nouveauMembre.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", nouveauMembre.Prenom);
                    cmd.Parameters.AddWithValue("@Adresse", nouveauMembre.Adresse ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tel", nouveauMembre.Telephone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", nouveauMembre.Email);
                    cmd.Parameters.AddWithValue("@MdpHash", hashedPassword);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // --- Opération Membre : Vérification de Connexion ---
        public Membre VerifierCredentials(string email, string motDePasseClair)
        {
            string query = "SELECT MembreID, Nom, Prenom, MotDePasseHash, StatutAdhesion FROM Membre WHERE Email = @Email";

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

                            // Vrai vérification du mot de passe
                            if (storedHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase))
                            {
                                return new Membre
                                {
                                    MembreID = reader.GetInt32(0),
                                    Nom = reader.GetString(1),
                                    Prenom = reader.GetString(2),
                                    StatutAdhesion = reader.GetString(4)
                                };
                            }
                        }
                    }
                }
            }
            return null; // Connexion échouée
        }

        // --- Opération Admin : Valider une Adhésion ---
        public bool ValiderAdhesion(int membreId)
        {
            string query = "UPDATE Membre SET StatutAdhesion = 'Valide' WHERE MembreID = @ID AND StatutAdhesion = 'En Attente'";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", membreId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}