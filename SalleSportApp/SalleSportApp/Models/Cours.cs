using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalleSportApp.Data.CoursDAO;

namespace SalleSportApp.Models
{
    public class Cours
    {
        public DateTime Horaire { get; set; }

        public string horaire { get; set; }
        public int CoursID { get; set; }

        public int CoachId { get; set; }

        public int SalleId { get; set; }
        public string NomCours { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; } // En minutes
        public IntensiteEnum Intensite { get; set; }
        public NiveauDifficulteEnum NiveauDifficulte { get; set; }
        public int CapaciteMax { get; set; }
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateHeure { get; set; }
        // public List<SessionCours> Sessions { get; set; }
    }
}
