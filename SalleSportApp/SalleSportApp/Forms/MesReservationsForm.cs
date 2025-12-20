using SalleSportApp.Models;
using SalleSportApp.Data;
using System;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    public partial class MesReservationsForm : Form
    {
        private readonly Membre _membreConnecte;
        private readonly ReservationDAO reservationDao = new ReservationDAO();

        public MesReservationsForm(Membre membre)
        {
            InitializeComponent(); // ⚠️ indispensable
            _membreConnecte = membre;

            ChargerReservations();
        }

        private void ChargerReservations()
        {
            dgvReservations.AutoGenerateColumns = true;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;

            dgvReservations.DataSource =
                reservationDao.GetReservationsByMembre(_membreConnecte.id);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une réservation.");
                return;
            }

            int reservationId =
                (int)dgvReservations.SelectedRows[0].Cells["Id"].Value;

            DialogResult confirm = MessageBox.Show(
                "Voulez-vous vraiment annuler cette réservation ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                bool succes = reservationDao.AnnulerReservation(
    reservationId,
    _membreConnecte.id
);

                if (succes)
                {
                    MessageBox.Show("Réservation annulée.");
                    ChargerReservations();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'annulation.");
                }
            }
        }

        private void btnReserver_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAnnulerReservation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.AllowUserToResizeColumns = false;
            this.dgvReservations.AllowUserToResizeRows = false;
            this.dgvReservations.ColumnHeadersHeight = 29;
            this.dgvReservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvReservations.Location = new System.Drawing.Point(0, 0);
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersWidth = 51;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(802, 352);
            this.dgvReservations.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Revenir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAnnulerReservation
            // 
            this.btnAnnulerReservation.Location = new System.Drawing.Point(625, 386);
            this.btnAnnulerReservation.Name = "btnAnnulerReservation";
            this.btnAnnulerReservation.Size = new System.Drawing.Size(165, 52);
            this.btnAnnulerReservation.TabIndex = 4;
            this.btnAnnulerReservation.Text = "Annuler reservation";
            this.btnAnnulerReservation.UseVisualStyleBackColor = true;
            this.btnAnnulerReservation.Click += new System.EventHandler(this.btnAnnulerReservation_Click);
            // 
            // MesReservationsForm
            // 
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.btnAnnulerReservation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvReservations);
            this.Name = "MesReservationsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnAnnulerReservation_Click(object sender, EventArgs e)


        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une réservation.");
                return;
            }

            int reservationId =
                (int)dgvReservations.SelectedRows[0].Cells["Id"].Value;

            DialogResult confirm = MessageBox.Show(
                "Voulez-vous vraiment annuler cette réservation ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                bool succes = reservationDao.AnnulerReservation(
    reservationId,
    _membreConnecte.id
);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

