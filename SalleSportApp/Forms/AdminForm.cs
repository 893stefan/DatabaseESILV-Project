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

        // 2. CONSTRUCTEUR QUI PREND UN ARGUMENT
        public AdminForm(Administrateur admin)
        {
            InitializeComponent();

            // Stocker l'objet Admin pour pouvoir l'utiliser ailleurs dans le formulaire
            _adminConnecte = admin;

            // Optionnel: Afficher un message de bienvenue ou le niveau de privilège
            this.Text = $"Administration - Connecté en tant que {_adminConnecte.Nom} ({_adminConnecte.NiveauPrivilege})";
        }
    }
}
