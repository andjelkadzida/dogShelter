using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class KuceBO
    {
        [Required(ErrorMessage = "Unesite ID Cipa")]
        public int IdCipa { get; set; }
        public string Rasa { get; set; }
        public string Pol { get; set; }
        public string Ime { get; set; }
        public int Starost { get; set; }
        public string IdVlasnika { get; set; }
        public Nullable<bool> UAzilu { get; set; }

        public bool ProveraValidnosti()
        {
            if ((IdCipa == 0) || (Rasa == null) || (Pol == null) || (Ime == null) || (Starost == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return "Ime: " + Ime + ", Rasa: " + Rasa + ", Pol: " + Pol + ", Starost: " + Starost;
        }
    }
}