using SalleSportApp.Models;
using SalleSportApp.Data;
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
    public partial class AdminCoachsForm : Form
    {
        private readonly Administrateur _adminConnecte;
        private readonly CoachDAO coachDao = new CoachDAO();
        private Coach coachSelectionne;
        public AdminCoachsForm(Administrateur admin)
        {
            InitializeComponent();
            _adminConnecte = admin;
            ChargerCoachs();
        }

        private void dgvMembres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChargerCoachs()
        {
            dgvCoach.DataSource = coachDao.GetAll();
            dgvCoach.ClearSelection();

            if (dgvCoach.Columns["Id"] != null)
                dgvCoach.Columns["Id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Nom et prénom obligatoires.");
                return;
            }

            var coach = new Coach
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Specialite = txtSpecialite.Text,
                Telephone = txtTelephone.Text,
                Email = txtEmail.Text
            };

            coachDao.Ajouter(coach);
            ChargerCoachs();
            ClearForm();
        }

        private void ClearForm()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtSpecialite.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvCoach.SelectedRows.Count == 0) return;

            int id = (int)dgvCoach.SelectedRows[0].Cells["Id"].Value;

            if (MessageBox.Show("Supprimer ce coach ?", "Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                coachDao.Supprimer(id);
                ChargerCoachs();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvCoach.SelectedRows.Count == 0) return;

            Coach c = CoachDepuisForm();
            c.Id = (int)dgvCoach.SelectedRows[0].Cells["Id"].Value;

            coachDao.Modifier(c);
            ChargerCoachs();
            MessageBox.Show("Coach modifié");
        }

        private Coach CoachDepuisForm()
        {
            return new Coach
            {
                Nom = txtNom.Text.Trim(),
                Prenom = txtPrenom.Text.Trim(),
                Specialite = txtSpecialite.Text.Trim(),
                Telephone = txtTelephone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DateEmbauche = dtpDateEmbauche.Value
            };
        }
    }
}
