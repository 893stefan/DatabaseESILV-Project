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
            string motDePasse = txtMotDePasse.Text.Trim();

            // Vérification des champs vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show(
                    "Veuillez entrer votre email et votre mot de passe.",
                    "Champs manquants",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // Création des DAO
                var adminDao = new AdminDAO();
                var membreDao = new MembreDAO();

                // 🔹 Vérification Admin
                var admin = adminDao.VerifierCredentials(email, motDePasse);
                if (admin != null)
                {
                    MessageBox.Show(
                        $"Bienvenue, Administrateur {admin.Email} !",
                        "Connexion Réussie",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    var adminForm = new AdminForm(admin);
                    adminForm.Show();
                    this.Hide();
                    return;
                }

                // 🔹 Vérification Membre
                var membre = membreDao.VerifierCredentials(email, motDePasse);
                if (membre != null)
                {
                    // ✅ Casting correct et accès à StatutAdhesion
                    if (membre.StatutAdhesion.ToLower() == "valide")
                    {
                        MessageBox.Show(
                            $"Bienvenue, Membre {membre.Prenom} !",
                            "Connexion Réussie",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        var membreForm = new MembreForm(membre);
                        membreForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Votre compte est actuellement au statut : {membre.StatutAdhesion}. Veuillez attendre la validation d'un administrateur.",
                            "Adhésion en Attente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    return;
                }

                // Email ou mot de passe incorrect
                MessageBox.Show(
                    "Email ou mot de passe incorrect.",
                    "Erreur de connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la connexion : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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