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
    public partial class AdminCoursForm : Form
    {
        private CoursDAO coursDao = new CoursDAO();
        private readonly Administrateur _adminConnecte;
        public AdminCoursForm(Administrateur admin)
        {
            InitializeComponent();
            _adminConnecte = admin;
            LoadCours();
        }

        private void LoadCours()
        {
            dgvCours.DataSource = null;
            dgvCours.DataSource = coursDao.GetCoursDisponibles();
            dgvCours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCours.ReadOnly = true;
            dgvCours.AllowUserToAddRows = false;
            dgvCours.AllowUserToDeleteRows = false;
            dgvCours.AllowUserToOrderColumns = false;
            dgvCours.MultiSelect = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvCours.SelectedRows.Count == 0) return;

            int id = (int)dgvCours.SelectedRows[0].Cells["Id"].Value;
            if (coursDao.Supprimer(id))
            {
                MessageBox.Show("Cours supprimé !");
                LoadCours();
            }
        }



        private void dgvCours_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCours.SelectedRows.Count == 0) return;
            txtNom.Text = dgvCours.SelectedRows[0].Cells["Nom"].Value.ToString();
            txtCapacite.Text = dgvCours.SelectedRows[0].Cells["CapaciteMax"].Value.ToString();
            txtHoraire.Text = dgvCours.SelectedRows[0].Cells["Horaire"].Value.ToString();
            txtCoachId.Text = dgvCours.SelectedRows[0].Cells["CoachId"].Value.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Cours c = new Cours
            {
                Nom = txtNom.Text,
                CapaciteMax = int.Parse(txtCapacite.Text),
                horaire = txtHoraire.Text,
                CoachId = int.Parse(txtCoachId.Text)
            };
            if (coursDao.Ajouter(c))
            {
                MessageBox.Show("Cours ajouté !");
                LoadCours();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCours.SelectedRows.Count == 0) return;

            Cours c = new Cours
            {
                Id = (int)dgvCours.SelectedRows[0].Cells["Id"].Value,
                Nom = txtNom.Text,
                CapaciteMax = int.Parse(txtCapacite.Text),
                horaire = txtHoraire.Text,
                CoachId = int.Parse(txtCoachId.Text)
            };

            if (coursDao.Modifier(c))
            {
                MessageBox.Show("Cours modifié !");
                LoadCours();
            }
        }

        private void txtCoachId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
