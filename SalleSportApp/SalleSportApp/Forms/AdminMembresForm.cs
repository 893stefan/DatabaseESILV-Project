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
    public partial class AdminMembresForm : Form
    {
        private readonly Administrateur _adminConnecte;
        public AdminMembresForm(Administrateur admin)
        {
            InitializeComponent();
            _adminConnecte = admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
