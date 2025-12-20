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

            AfficherBienvenue();
            AfficherStatus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AfficherBienvenue()
        {
            label1.Text = $"Bienvenue {_membreConnecte.Prenom} {_membreConnecte.Nom}";
        }

        private void AfficherStatus()
        {
            label3.Text = $"Statut : {_membreConnecte.StatutAdhesion} ";
        }
        private void panelHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnInfos_Click(object sender, EventArgs e)
        {
            MembreInfosForm infosForm = new MembreInfosForm(_membreConnecte);
            infosForm.ShowDialog(); // bloque la fenêtre par-dessus
        }

        // 🔹 Réserver un cours
        private void btnReserverCours_Click(object sender, EventArgs e)
        {
            ReservationCoursForm reservationForm = new ReservationCoursForm(_membreConnecte);
            reservationForm.ShowDialog();
        }

        // 🔹 Mes réservations
        private void btnMesReservations_Click(object sender, EventArgs e)
        {
            MesReservationsForm mesReservationsForm = new MesReservationsForm(_membreConnecte);
            mesReservationsForm.ShowDialog();
        }

        // 🔹 Déconnexion
        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }
    }
    }

