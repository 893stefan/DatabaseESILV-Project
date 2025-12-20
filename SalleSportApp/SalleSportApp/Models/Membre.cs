using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Models
{
    public class Membre
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string MotDePasseHash { get; set; }
        public DateTime DateInscription { get; set; }
        // 'En Attente', 'Valide', 'Suspendu'
        public string StatutAdhesion { get; set; }

        // public List<Reservation> Reservations { get; set; } 
        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
    }
        
}
