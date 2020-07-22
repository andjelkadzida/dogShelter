using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azilZaPse.Models.Interfejsi
{
    interface IAuthInterface
    {
        bool DaLiJeValidno(KorisnikBO korisnik);
        void DodajKorisnika(KorisnikBO korisnik);
    }
}
