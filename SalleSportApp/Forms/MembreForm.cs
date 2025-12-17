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
        }
    }
}
