using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public DateTime DateReservation { get; set; }
        public string StatutReservation { get; set; } // 'Confirmée', 'Annulée'

        // Clés Étrangères
        public int MembreID { get; set; }
        public int SessionID { get; set; }

        // public Membre Membre { get; set; }
        // public SessionCours Session { get; set; }
    }
}
