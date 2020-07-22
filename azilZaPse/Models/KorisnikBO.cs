using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class KorisnikBO
    {
        public int IdKorisnika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Sifra { get; set; }
    }
}