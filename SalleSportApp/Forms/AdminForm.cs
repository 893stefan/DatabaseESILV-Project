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
    public partial class AdminForm : Form
    {
        private readonly Administrateur _adminConnecte;
        private readonly AdminDAO adminDao = new AdminDAO();
        private readonly MembreDAO membreDao = new MembreDAO();
        private readonly CoursDAO coursDao = new CoursDAO();
        private readonly CoachDAO coachDao = new CoachDAO();

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public AdminForm(Administrateur admin)
        {
            InitializeComponent();

            // Stocker l'objet Admin pour pouvoir l'utiliser ailleurs dans le formulaire
            _adminConnecte = admin;

            // Optionnel: Afficher un message de bienvenue ou le niveau de privilège
            this.Text = $"Administration - Connecté en tant que {_adminConnecte.Nom} ({_adminConnecte.NiveauPrivilege})";
            this.lblAdminHeader.Text = $"Bienvenue {_adminConnecte.Prenom} {_adminConnecte.Nom}";
            this.Shown += AdminForm_Shown;
            ConfigureGrids();
        }

        private void AdminForm_Shown(object sender, EventArgs e)
        {
            ChargerMembres();
            ChargerCours();
            ChargerCoachs();
            ChargerRapport();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
            Close();
        }

        private void btnRefreshMembres_Click(object sender, EventArgs e)
        {
            ChargerMembres();
        }

        private void btnValiderMembre_Click(object sender, EventArgs e)
        {
            if (dgvMembres.CurrentRow?.DataBoundItem is Membre membre)
            {
                if (membreDao.ValiderAdhesion(membre.MembreID))
                {
                    MessageBox.Show("Adhésion validée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerMembres();
                }
                else
                {
                    MessageBox.Show("Impossible de valider l'adhésion.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez un membre.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAjouterCours_Click(object sender, EventArgs e)
        {
            string nom = Prompt("Ajouter cours", "Nom du cours");
            if (string.IsNullOrWhiteSpace(nom))
            {
                return;
            }

            string description = Prompt("Ajouter cours", "Description (optionnel)");
            if (!TryPromptInt("Ajouter cours", "Durée (minutes)", out int duree))
            {
                return;
            }

            string intensite = Prompt("Ajouter cours", "Intensité (faible/moyenne/elevee)");
            if (!TryPromptInt("Ajouter cours", "Niveau difficulté (1-5)", out int niveau))
            {
                return;
            }

            if (!TryPromptInt("Ajouter cours", "Capacité max", out int capacite))
            {
                return;
            }

            Cours nouveau = new Cours
            {
                NomCours = nom,
                Description = description,
                Duree = duree,
                Intensite = intensite,
                NiveauDifficulte = niveau,
                CapaciteMax = capacite
            };

            if (coursDao.AjouterCours(nouveau))
            {
                MessageBox.Show("Cours ajouté.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerCours();
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter le cours.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerCours_Click(object sender, EventArgs e)
        {
            if (dgvCours.CurrentRow?.DataBoundItem is Cours cours)
            {
                if (coursDao.SupprimerCours(cours.CoursID))
                {
                    MessageBox.Show("Cours supprimé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCours();
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer le cours.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez un cours.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAjouterCoach_Click(object sender, EventArgs e)
        {
            string nom = Prompt("Ajouter coach", "Nom");
            if (string.IsNullOrWhiteSpace(nom))
            {
                return;
            }

            string prenom = Prompt("Ajouter coach", "Prénom");
            if (string.IsNullOrWhiteSpace(prenom))
            {
                return;
            }

            string specialite = Prompt("Ajouter coach", "Spécialité (optionnel)");
            string telephone = Prompt("Ajouter coach", "Téléphone (optionnel)");
            string email = Prompt("Ajouter coach", "Email (optionnel)");
            string formation = Prompt("Ajouter coach", "Formation (optionnel)");
            string description = Prompt("Ajouter coach", "Description (optionnel)");

            Coach coach = new Coach
            {
                Nom = nom,
                Prenom = prenom,
                Specialite = specialite,
                Telephone = telephone,
                Email = email,
                Formation = formation,
                Description = description
            };

            if (coachDao.AjouterCoach(coach))
            {
                MessageBox.Show("Coach ajouté.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerCoachs();
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter le coach.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerCoach_Click(object sender, EventArgs e)
        {
            if (dgvCoachs.CurrentRow?.DataBoundItem is Coach coach)
            {
                if (coachDao.SupprimerCoach(coach.CoachID))
                {
                    MessageBox.Show("Coach supprimé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCoachs();
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer le coach.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez un coach.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenererRapport_Click(object sender, EventArgs e)
        {
            ChargerRapport();
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

        private void ChargerMembres()
        {
            dgvMembres.DataSource = adminDao.GetMembresEnAttente();
        }

        private void ChargerCours()
        {
            dgvCours.DataSource = coursDao.GetCours();
        }

        private void ChargerCoachs()
        {
            dgvCoachs.DataSource = coachDao.GetCoachs();
        }

        private void ChargerRapport()
        {
            lstRapports.Items.Clear();
            foreach (string ligne in adminDao.GetRapportResume())
            {
                lstRapports.Items.Add(ligne);
            }
        }

        private void ConfigureGrids()
        {
            ConfigureGrid(dgvMembres);
            ConfigureGrid(dgvCours);
            ConfigureGrid(dgvCoachs);
        }

        private void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private string Prompt(string title, string label)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 420;
                prompt.Height = 150;
                prompt.Text = title;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label { Left = 10, Top = 10, Width = 380, Text = label };
                TextBox textBox = new TextBox { Left = 10, Top = 35, Width = 380 };
                Button confirmation = new Button { Text = "OK", Left = 230, Width = 75, Top = 70, DialogResult = DialogResult.OK };
                Button cancel = new Button { Text = "Annuler", Left = 315, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };
                confirmation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                return prompt.ShowDialog(this) == DialogResult.OK ? textBox.Text.Trim() : null;
            }
        }

        private bool TryPromptInt(string title, string label, out int value)
        {
            value = 0;
            string input = Prompt(title, label);
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            if (!int.TryParse(input, out value))
            {
                MessageBox.Show("Valeur numérique invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
