using System;
using Npgsql;
using System.Configuration;
// Pour System.Data.ConnectionState
using System.Data;

namespace SalleSportApp.Data
{
    public class Database
    {
        // Chaîne de connexion PostgreSQL (App.config)
        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
            ?? throw new InvalidOperationException("Missing DefaultConnection in App.config.");

        /// <summary>
        /// Crée et retourne une nouvelle instance de connexion PostgreSQL (NON ouverte).
        /// </summary>
        public NpgsqlConnection CreateConnection()
        {
            // Retourne simplement l'objet NpgsqlConnection.
            // C'est aux classes DAO d'ouvrir et de fermer la connexion avec 'using'.
            return new NpgsqlConnection(connString);
        }

        // --- Méthode précédente simplifiée (Optionnel) ---
        // Vous pouvez garder cette méthode pour vérifier rapidement la connexion lors du démarrage
        public bool TestConnection()
        {
            using (var conn = CreateConnection()) // Le 'using' assure la fermeture et la libération
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connexion PostgreSQL réussie !");
                    return true;
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Erreur de connexion : " + ex.Message);
                    // Ne pas remonter (throw) ici si c'est juste un test.
                    return false;
                }
            }
        }
    }
}
