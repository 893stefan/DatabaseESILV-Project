using System;
using System.Windows.Forms;
using SalleSportApp.Data;
using SalleSportApp.Models;
// Ajout des autres formulaires que nous allons ouvrir
using SalleSportApp.Forms;

namespace SalleSportApp.Forms
{
    public partial class LoginForm : Form
    {
        // Instanciation des Data Access Objects nécessaires pour la connexion
        private readonly AdminDAO adminDao = new AdminDAO();
        private readonly MembreDAO membreDao = new MembreDAO();

        public LoginForm()
        {
            InitializeComponent();

            // Assurer que le champ de mot de passe masque le texte
            this.txtMotDePasse.UseSystemPasswordChar = true;

            // Connexion des événements (si ce n'est pas fait dans le Designer)
            this.btnConnexion.Click += new EventHandler(this.btnConnexion_Click);
            this.linkInscription.Click += new EventHandler(this.linkInscription_Click);
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez entrer votre email et votre mot de passe.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Tentative de connexion en tant qu'Administrateur
            Administrateur admin = adminDao.VerifierCredentials(email, motDePasse);
            if (admin != null)
            {
                // Connexion Admin réussie
                MessageBox.Show($"Bienvenue, Administrateur {admin.Prenom} !", "Connexion Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ouvre la fenêtre AdminForm
                AdminForm adminForm = new AdminForm(admin);
                adminForm.Show();
                this.Hide(); // Cache la fenêtre de connexion
                return;
            }

            // 2. Si non Admin, Tentative de connexion en tant que Membre
            Membre membre = membreDao.VerifierCredentials(email, motDePasse);
            if (membre != null)
            {
                // Vérifier si l'adhésion est valide
                if (string.Equals(membre.StatutAdhesion, "Valide", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Bienvenue, Membre {membre.Prenom} !", "Connexion Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ouvre la fenêtre MembreForm
                    MembreForm membreForm = new MembreForm(membre);
                    membreForm.Show();
                    this.Hide(); // Cache la fenêtre de connexion
                }
                else
                {
                    // L'utilisateur existe, mais l'administrateur ne l'a pas encore validé
                    MessageBox.Show($"Votre compte est actuellement au statut : {membre.StatutAdhesion}. Veuillez attendre la validation d'un administrateur.", "Adhésion en Attente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // 3. Échec de la connexion (Email/Mot de passe incorrects)
            MessageBox.Show("Email ou mot de passe incorrect.", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkInscription_Click(object sender, EventArgs e)
        {
            // Ouvre la fenêtre d'inscription
            InscriptionForm inscriptionForm = new InscriptionForm();
            inscriptionForm.ShowDialog(); // Utilisation de ShowDialog pour rester au-dessus
        }

        // Ajoutez ici la gestion de l'événement FormClosing pour fermer correctement l'application
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Si le processus principal se ferme (LoginForm est caché, mais c'est le formulaire initial)
            if (Application.OpenForms.Count == 1 && Application.OpenForms[0] == this)
            {
                Application.Exit();
            }
        }
    }
}
