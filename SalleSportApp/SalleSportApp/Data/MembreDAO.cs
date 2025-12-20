using Npgsql;
using SalleSportApp.Forms;
using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography; // Nécessaire pour simuler le hachage
using System.Text;
using System.Windows.Forms;

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
            string hashedPassword = HashPassword(motDePasseClair);

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Créer l'utilisateur
                        string insertUtilisateurQuery = @"
                    INSERT INTO utilisateur (email, mot_de_passe_hash, role, telephone)
                    VALUES (@Email, @MdpHash,@Role::role_admin_enum, @Telephone)
                    RETURNING id;";

                        int idUtilisateur;
                        using (NpgsqlCommand cmdUser = new NpgsqlCommand(insertUtilisateurQuery, conn))
                        {
                            cmdUser.Parameters.AddWithValue("@Email", nouveauMembre.Email);
                            cmdUser.Parameters.AddWithValue("@MdpHash", hashedPassword);
                            cmdUser.Parameters.AddWithValue("@Role", "Membre"); // rôle par défaut
                            cmdUser.Parameters.AddWithValue("@Telephone", (object)nouveauMembre.Telephone ?? DBNull.Value);
                            
                            idUtilisateur = (int)cmdUser.ExecuteScalar();
                        }

                        // 2️⃣ Créer le membre
                        string insertMembreQuery = @"
                    INSERT INTO membre (nom, prenom, adresse, telephone, email, date_inscription, statut_inscription, fk_utilisateur_id)
                    VALUES (@Nom, @Prenom, @Adresse, @Telephone, @Email, @DateInscription, @Statut::statut_inscription_membre_enum, @IdUtilisateur);";

                        using (NpgsqlCommand cmdMembre = new NpgsqlCommand(insertMembreQuery, conn))
                        {
                            cmdMembre.Parameters.AddWithValue("@Nom", nouveauMembre.Nom);
                            cmdMembre.Parameters.AddWithValue("@Prenom", nouveauMembre.Prenom);
                            cmdMembre.Parameters.AddWithValue("@Adresse", (object)nouveauMembre.Adresse ?? DBNull.Value);
                            cmdMembre.Parameters.AddWithValue("@Telephone", (object)nouveauMembre.Telephone ?? DBNull.Value);
                            cmdMembre.Parameters.AddWithValue("@Email", nouveauMembre.Email);
                            cmdMembre.Parameters.AddWithValue("@DateInscription", DateTime.Now);
                            cmdMembre.Parameters.AddWithValue("@Statut", "en_attente"); // correspond à l'ENUM PostgreSQL
                            cmdMembre.Parameters.AddWithValue("@IdUtilisateur", idUtilisateur);

                            cmdMembre.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        {
                            transaction.Rollback();
                            Console.WriteLine("Erreur lors de l'inscription : " + ex.Message);
                            MessageBox.Show("Erreur lors de l'inscription : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
        }


        // --- Opération Membre : Vérification de Connexion ---
        public Membre VerifierCredentials(string email, string motDePasseClair)
        {
            string query = @"
        SELECT u.id, u.email, u.mot_de_passe_hash,m.id as id_membre, m.nom, m.prenom, m.statut_inscription
        FROM utilisateur u
        JOIN membre m ON m.fk_utilisateur_id = u.id
        WHERE u.email = @Email;
    ";
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
                            string inputHash = HashPassword(motDePasseClair);

                            if (storedHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase))
                            {
                                // Retourne un objet Membre typé avec StatutAdhesion
                                return new Membre
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id_membre")),
                                    Nom = reader.GetString(reader.GetOrdinal("nom")),
                                    Prenom = reader.GetString(reader.GetOrdinal("prenom")),
                                    Email = reader.GetString(reader.GetOrdinal("email")),
                                    StatutAdhesion = reader.GetString(reader.GetOrdinal("statut_inscription"))
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
            string query = @"
        UPDATE membre
        SET statut_inscription = 'valide'
        WHERE fk_utilisateur_id = @ID AND statut_inscription = 'en_attente';
    ";

            using (NpgsqlConnection conn = db.CreateConnection())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", membreId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows updated: " + rowsAffected); // 🔹 debug
                    return rowsAffected > 0;
                }
            }
        }

        public List<Membre> GetMembresEnAttente()
        {
            var liste = new List<Membre>();
            string query = @"
        SELECT u.id, u.email, m.nom, m.prenom, m.statut_inscription
        FROM utilisateur u
        JOIN membre m ON m.fk_utilisateur_id = u.id
        WHERE m.statut_inscription = 'en_attente';
    ";

            using (var conn = db.CreateConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Membre
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nom = reader.GetString(reader.GetOrdinal("nom")),
                            Prenom = reader.GetString(reader.GetOrdinal("prenom")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            StatutAdhesion = reader.GetString(reader.GetOrdinal("statut_inscription"))
                        });
                    }
                }
            }
            return liste;
        }


    }

}