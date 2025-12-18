using SalleSportApp.Data;
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
        private readonly ReservationDAO reservationDao = new ReservationDAO();

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public MembreForm(Membre membre)
        {
            InitializeComponent();

            // Stockage de l'objet Membre
            _membreConnecte = membre;
            this.lblMembreHeader.Text = $"Bienvenue {_membreConnecte.Prenom} {_membreConnecte.Nom}";
            this.lblProfilInfo.Text = $"Nom: {_membreConnecte.Nom}\nPrénom: {_membreConnecte.Prenom}\nEmail: {_membreConnecte.Email}";
            this.Shown += MembreForm_Shown;
            ConfigureGrids();
        }

        private void MembreForm_Shown(object sender, EventArgs e)
        {
            ChargerCours();
            ChargerReservations();
            ChargerHistorique();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
            Close();
        }

        private void btnRefreshCours_Click(object sender, EventArgs e)
        {
            ChargerCours();
        }

        private void btnReserver_Click(object sender, EventArgs e)
        {
            if (dgvCours.CurrentRow == null || dgvCours.CurrentRow.Cells["SessionID"]?.Value == null)
            {
                MessageBox.Show("Sélectionnez une session de cours.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int sessionId = Convert.ToInt32(dgvCours.CurrentRow.Cells["SessionID"].Value);
            if (reservationDao.ReserverCours(_membreConnecte.MembreID, sessionId))
            {
                MessageBox.Show("Réservation confirmée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerReservations();
                ChargerHistorique();
                ChargerCours();
            }
            else
            {
                MessageBox.Show("Impossible de réserver ce cours.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshReservations_Click(object sender, EventArgs e)
        {
            ChargerReservations();
        }

        private void btnAnnulerReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null || dgvReservations.CurrentRow.Cells["ReservationID"]?.Value == null)
            {
                MessageBox.Show("Sélectionnez une réservation.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservationId = Convert.ToInt32(dgvReservations.CurrentRow.Cells["ReservationID"].Value);
            if (reservationDao.AnnulerReservation(reservationId, _membreConnecte.MembreID))
            {
                MessageBox.Show("Réservation annulée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerReservations();
                ChargerHistorique();
                ChargerCours();
            }
            else
            {
                MessageBox.Show("Impossible d'annuler la réservation.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshHistorique_Click(object sender, EventArgs e)
        {
            ChargerHistorique();
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

        private void ChargerCours()
        {
            dgvCours.DataSource = reservationDao.GetSessionsDisponibles();
        }

        private void ChargerReservations()
        {
            dgvReservations.DataSource = reservationDao.GetReservationsMembre(_membreConnecte.MembreID);
        }

        private void ChargerHistorique()
        {
            dgvHistorique.DataSource = reservationDao.GetHistoriqueMembre(_membreConnecte.MembreID);
        }

        private void ConfigureGrids()
        {
            ConfigureGrid(dgvCours);
            ConfigureGrid(dgvReservations);
            ConfigureGrid(dgvHistorique);
        }

        private void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
