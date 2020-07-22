using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class VlasnikBO
    {
        public string IdVlasnika { get; set; }
        public string ImeVlasnika { get; set; }
        public string PrezimeVlasnika { get; set; }
        public string Adresa { get; set; }

        public bool ProveraValidnosti()
        {
            if ((IdVlasnika == null) || (ImeVlasnika == null) || (PrezimeVlasnika == null) || (Adresa == null))
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