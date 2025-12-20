using SalleSportApp.Models;
using System;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    public partial class MembreInfosForm : Form
    {
        private readonly Membre _membreConnecte;

        public MembreInfosForm(Membre membre)
        {
            InitializeComponent();

            if (membre == null)
            {
                MessageBox.Show("Aucun membre connecté.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _membreConnecte = membre;
            AfficherInfos();
        }

        private void AfficherInfos()
        {
            lblNom.Text = $"Nom : {_membreConnecte.Nom}";
            lblPrenom.Text = $"Prénom : {_membreConnecte.Prenom}";
            lblEmail.Text = $"Email : {_membreConnecte.Email}";
            lblTelephone.Text = $"Téléphone : {_membreConnecte.Telephone ?? "Non renseigné"}";
            lblAdresse.Text = $"Adresse : {_membreConnecte.Adresse ?? "Non renseignée"}";
            lblStatut.Text = $"Statut : {_membreConnecte.StatutAdhesion}";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFermer_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
