using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models
{
    public class ProizvodnjaBO
    {
        public int IdProizvoda { get; set; }
        public int IdProizvodjaca { get; set; }
        public Nullable<int> DostupneKolicine { get; set; }
    }
}