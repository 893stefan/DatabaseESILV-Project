using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class Cours
    {
        public int CoursID { get; set; }
        public string NomCours { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; } // En minutes
        public string Intensite { get; set; }
        public int NiveauDifficulte { get; set; } // 1 à 5
        public int CapaciteMax { get; set; }

        // public List<SessionCours> Sessions { get; set; }
    }
}
