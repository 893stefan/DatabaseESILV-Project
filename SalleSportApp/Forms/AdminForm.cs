using SalleSportApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    public partial class AdminForm : Form
    {
        private readonly Administrateur _adminConnecte;

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public AdminForm(Administrateur admin)
        {
            InitializeComponent();

            // Stocker l'objet Admin pour pouvoir l'utiliser ailleurs dans le formulaire
            _adminConnecte = admin;

            // Optionnel: Afficher un message de bienvenue ou le niveau de privilège
            this.Text = $"Administration - Connecté en tant que {_adminConnecte.Nom} ({_adminConnecte.NiveauPrivilege})";
            this.lblAdminHeader.Text = $"Bienvenue {_adminConnecte.Prenom} {_adminConnecte.Nom}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
            Close();
        }

        private void btnRefreshMembres_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : rafraîchir la liste des membres.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnValiderMembre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : valider l'adhésion d'un membre sélectionné.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAjouterCours_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : ajouter un cours.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSupprimerCours_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : supprimer un cours.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAjouterCoach_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : ajouter un coach.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSupprimerCoach_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : supprimer un coach.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenererRapport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : générer un rapport.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = Application.OpenForms.OfType<LoginForm>().FirstOrDefault();
            if (loginForm != null)
            {
                loginForm.Show();
                loginForm.BringToFront();
            }
        }
    }
}
