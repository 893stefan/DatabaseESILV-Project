using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class SessionCours
    {
        public int SessionID { get; set; }
        public DateTime DateHeureDebut { get; set; }
        public DateTime DateHeureFin { get; set; }
        public string Statut { get; set; } // 'Prévue', 'Annulée', 'Terminée'

        // Clés Étrangères
        public int CoursID { get; set; }
        public int CoachID { get; set; }
        public int SalleID { get; set; }

        // public Cours Cours { get; set; }
        // public Coach Coach { get; set; }
        // public Salle Salle { get; set; }
        // public List<Reservation> Reservations { get; set; } 
    }
}
