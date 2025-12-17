using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Forms
{
    public class Administrateur
    {
        public int AdminID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasseHash { get; set; }
        // Utiliser un enum serait mieux en production, mais un string suffira ici
        public string NiveauPrivilege { get; set; }
        public string Telephone { get; set; }

        // Navigation properties (pour l'avenir avec un ORM comme Entity Framework)
        // public List<Membre> MembresGeres { get; set; } 
    }
}
