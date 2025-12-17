using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class Salle
    {
        public int SalleID { get; set; }
        public string NomSalle { get; set; }
        public int Capacite { get; set; }
        public string Localisation { get; set; }

        // public List<SessionCours> SessionsQuiSontDedans { get; set; }
    }
}
