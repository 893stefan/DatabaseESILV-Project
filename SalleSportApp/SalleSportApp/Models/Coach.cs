using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }

        public string Certifications { get; set; }
        public string Formations { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Formation { get; set; }
        public string Description { get; set; }
        public DateTime DateEmbauche { get; set; }
    }
    // public List<SessionCours> SessionsDonnees { get; set; }
}

