using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class KartonPsaBO
    {
        public int IdCipa { get; set; }
        public Nullable<bool> DaLiJeVakcinisan { get; set; }
        public string Alergije { get; set; }
        public Nullable<bool> OciscenOdParazita { get; set; }

        public bool ProveraValidnosti()
        {
            if ((IdCipa == 0) || (DaLiJeVakcinisan == null) || (OciscenOdParazita == null) || (String.IsNullOrEmpty(Alergije)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}