using SalleSportApp.Data;
using System;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- TEST DE CONNEXION IMMÉDIAT ---
            Database dbTest = new Database();

            if (dbTest.TestConnection())
            {
                // Connexion réussie, lancer l'application normalement
                Application.Run(new LoginForm());
            }
            else
            {
                // Connexion échouée, informer l'utilisateur et fermer l'application
                MessageBox.Show(
                    "Impossible de se connecter à la base de données PostgreSQL.\n" +
                    "Vérifiez que le serveur est démarré et que les identifiants dans Database.cs sont corrects.",
                    "Erreur Critique de Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            // ------------------------------------
        }
    }
}