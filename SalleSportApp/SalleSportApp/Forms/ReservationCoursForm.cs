using SalleSportApp.Data;
using SalleSportApp.Models;
using System;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    public partial class ReservationCoursForm : Form
    {
        private readonly Membre _membreConnecte;
        private readonly CoursDAO coursDao = new CoursDAO();

        public ReservationCoursForm(Membre membre)
        {
            InitializeComponent(); // vient du Designer
            _membreConnecte = membre;
            LoadCoursDisponibles();
        }

        private void LoadCoursDisponibles()
        {
            var listeCours = coursDao.GetCoursDisponibles();
            dgvCours.DataSource = listeCours;

            dgvCours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCours.MultiSelect = false;

            if (dgvCours.Columns["Id"] != null)
                dgvCours.Columns["Id"].Visible = false;
        }

        private void btnReserver_Click(object sender, EventArgs e)
        {
            if (dgvCours.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un cours à réserver.", "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int coursId = (int)dgvCours.SelectedRows[0].Cells["Id"].Value;

            bool succes = coursDao.ReserverCours(_membreConnecte.id, coursId);

            if (succes)
            {
                MessageBox.Show("Cours réservé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCoursDisponibles(); // Recharge la liste si nécessaire
            }
            else
            {
                MessageBox.Show("Impossible de réserver ce cours.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
