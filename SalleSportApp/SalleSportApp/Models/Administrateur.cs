using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleSportApp.Forms
{
    public class Administrateur
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
       
        // Navigation properties (pour l'avenir avec un ORM comme Entity Framework)
        // public List<Membre> MembresGeres { get; set; } 
    }
}
