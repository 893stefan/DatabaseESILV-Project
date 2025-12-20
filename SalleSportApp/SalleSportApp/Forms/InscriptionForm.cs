using SalleSportApp.Data;
using SalleSportApp.Models;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace SalleSportApp.Forms
{
    public partial class InscriptionForm : Form
    {
        private readonly MembreDAO membreDao = new MembreDAO();

        public InscriptionForm()
        {
            InitializeComponent();

            // Assurer que les champs de mot de passe masquent le texte
            this.txtMotDePasse.UseSystemPasswordChar = true;
            this.txtConfirmerMotDePasse.UseSystemPasswordChar = true;

            // Lier le bouton d'inscription à la méthode (si ce n'est pas fait dans le designer)
            this.btnInscrire.Click += new EventHandler(this.btnInscrire_Click);
            this.btnAnnuler.Click += new EventHandler(this.btnAnnuler_Click);
        }

        private void btnInscrire_Click(object sender, EventArgs e)
        {
            // 1. Récupération des données et Validation
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string mdp = txtMotDePasse.Text;
            string confirmationMdp = txtConfirmerMotDePasse.Text;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Le Nom, l'Email et le Mot de passe sont obligatoires.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mdp != confirmationMdp)
            {
                MessageBox.Show("Le mot de passe et sa confirmation ne correspondent pas.", "Erreur de mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Ajouter une validation de format d'email plus robuste ici

            // 2. Création de l'objet Membre
            Membre nouveauMembre = new Membre
            {
                Nom = nom,
                Prenom = prenom,
                Email = email,
                // Les autres champs (Adresse, Téléphone) sont laissés à null/vide pour le squelette
            };

            // 3. Appel du DAO pour l'insertion
            try
            {
                if (membreDao.AjouterMembre(nouveauMembre, mdp))
                {
                    MessageBox.Show("Inscription réussie ! Votre compte est maintenant 'En Attente' de validation par un administrateur.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fermer la fenêtre après l'inscription
                }
                else
                {
                     
                    MessageBox.Show("Échec de l'inscription (probablement un email déjà utilisé).", "Erreur d'insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions non liées à la BDD (ex: la BDD est hors ligne)
                MessageBox.Show($"Une erreur est survenue lors de l'inscription : {ex.Message}", "Erreur Système", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer simplement la fenêtre
        }
    }
}