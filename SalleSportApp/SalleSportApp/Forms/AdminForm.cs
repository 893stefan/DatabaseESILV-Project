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
    public partial class AdminForm : Form
    {
        private readonly Administrateur _adminConnecte;

        private readonly MembreDAO membreDao = new MembreDAO();

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public AdminForm(Administrateur admin)
        {
            InitializeComponent();

            // Stocker l'objet Admin pour pouvoir l'utiliser ailleurs dans le formulaire
            _adminConnecte = admin;

            // Optionnel: Afficher un message de bienvenue ou le niveau de privilège
            this.Text = $"Administration - Connecté en tant que {_adminConnecte.Email} ({_adminConnecte.Role})";
            
        }
            
       

        

        

        private void btn_revenir_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminDemandesForm(_adminConnecte).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminMembresForm(_adminConnecte).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AdminCoachsForm(_adminConnecte).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AdminCoursForm(_adminConnecte).ShowDialog();
        }
    }
}
    