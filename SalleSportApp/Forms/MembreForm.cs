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
    public partial class MembreForm : Form
    {
        private readonly Membre _membreConnecte;

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public MembreForm(Membre membre)
        {
            InitializeComponent();

            // Stockage de l'objet Membre
            _membreConnecte = membre;
            this.lblMembreHeader.Text = $"Bienvenue {_membreConnecte.Prenom} {_membreConnecte.Nom}";
            this.lblProfilInfo.Text = $"Nom: {_membreConnecte.Nom}\nPrénom: {_membreConnecte.Prenom}\nEmail: {_membreConnecte.Email}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
            Close();
        }

        private void btnRefreshCours_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : rafraîchir la liste des cours.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReserver_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : réserver un cours sélectionné.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefreshReservations_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : rafraîchir les réservations.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnulerReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : annuler une réservation sélectionnée.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefreshHistorique_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prototype : afficher l'historique des inscriptions.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
