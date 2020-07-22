using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class DokumentacijaBO
    {
        public int IdDokumentacije { get; set; }
        public string TekstDokumentacije { get; set; }
        public string DatumIzdavanja { get; set; }
        public int IdCipa { get; set; }
        public string IdVlasnika { get; set; }

        public bool ProveraValidnosti()
        {
            if ((IdCipa == 0) || (IdVlasnika == null))
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