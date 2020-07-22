using azilZaPse.Models.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models.Repository_Ef_Baza
{
    public class AuthRepository : IAuthInterface
    {
        private AzilZaPseEntities1 azilZaPseEntities = new AzilZaPseEntities1();
        public bool DaLiJeValidno(KorisnikBO korisnikBO)
        {
            bool daLiJeValidno = azilZaPseEntities.Korisniks.Any(x => x.korisnickoime == korisnikBO.KorisnickoIme && x.sifra == korisnikBO.Sifra);
            return daLiJeValidno;
        }

        public void DodajKorisnika(KorisnikBO korisnikBO)
        {
            if (DaLiJeValidno(korisnikBO))
            {
                return;
            }
            else
            {
                Korisnik korisnik = new Korisnik()
                {
                    email = korisnikBO.Email,
                    sifra = korisnikBO.Sifra,
                    korisnickoime = korisnikBO.KorisnickoIme
                };
                azilZaPseEntities.Korisniks.Add(korisnik);
                azilZaPseEntities.SaveChanges();
            }
        }

       /* public List<string> UzmiUlogeZaKorisnika(string korisnickoIme)
        {
            Korisnik korisnik = azilZaPseEntities.Korisniks.FirstOrDefault(a => a.korisnickoime == korisnickoIme);
        }*/
    }
}