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
    public partial class AdminDemandesForm : Form
    {
        private readonly Administrateur _adminConnecte;


        private readonly MembreDAO membreDao = new MembreDAO();
        public AdminDemandesForm(Administrateur admin)
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            _adminConnecte = admin;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ChargerMembres();
        }


        private void ChargerMembres()
        {
            // On récupère tous les membres dont l'adhésion est "en_attente"
            var membresEnAttente = membreDao.GetMembresEnAttente();
            dgvMembres.DataSource = membresEnAttente;
            dgvMembres.Columns["id"].Visible = false; // on cache l'id si nécessaire
            Console.WriteLine("Membres en attente : " + membresEnAttente.Count); // 🔹 DEBUG 
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dgvMembres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un membre à valider.", "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On récupère l'id du membre sélectionné
            int membreId = (int)dgvMembres.SelectedRows[0].Cells["id"].Value;
            bool succes = membreDao.ValiderAdhesion(membreId);

            if (succes)
            {
                MessageBox.Show("Membre validé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerMembres(); // Recharge la liste
            }
            else
            {
                MessageBox.Show("Impossible de valider ce membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_revenir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
