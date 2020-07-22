using azilZaPse.Models.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models.Repository_Ef_Baza
{
    public class ProizvodiRepository : IProizvodInterface
    {
        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();
        public IEnumerable<ProizvedeniProizvodiBO> NadjiProizvod(int idProizvoda)
        {
            List<ProizvedeniProizvodiBO> lista = new List<ProizvedeniProizvodiBO>();
            Proizvod proizvod = azilEntities.Proizvods.FirstOrDefault(x => x.idProizvoda == idProizvoda);
            
            

            foreach (Proizvodnja proizvodnja in azilEntities.Proizvodnjas.Where(x => x.idProizvoda == idProizvoda))
            {
                ProizvodBO trazeniProizvod = new ProizvodBO();
                ProizvodjacBO trazeniProizvodjac = new ProizvodjacBO();
                ProizvodnjaBO trazenaProizvodnja = new ProizvodnjaBO();
                ProizvedeniProizvodiBO noviProizvedeniProizvod = new ProizvedeniProizvodiBO();
                trazeniProizvod.IdProizvoda = proizvod.idProizvoda;
                trazeniProizvod.Kolicina = proizvod.kolicina;
                trazeniProizvod.NazivProizvoda = proizvod.nazivProizvoda;
                trazenaProizvodnja.IdProizvoda = proizvodnja.idProizvoda;
                trazenaProizvodnja.IdProizvodjaca = proizvodnja.idProizvodjaca;
                trazenaProizvodnja.DostupneKolicine = proizvodnja.dostupneKolicine;

                Proizvodjac proizvodjac = azilEntities.Proizvodjacs.FirstOrDefault(x => x.idProizvodjaca == proizvodnja.idProizvodjaca);
                trazeniProizvodjac.IdProizvodjaca = proizvodjac.idProizvodjaca;
                trazeniProizvodjac.NazivProizvodjaca = proizvodjac.nazivProizvodjaca;
                trazeniProizvodjac.Grad = proizvodjac.grad;
                trazeniProizvodjac.Ulica = proizvodjac.ulica;
                noviProizvedeniProizvod.proizvod = trazeniProizvod;
                noviProizvedeniProizvod.proizvodjac = trazeniProizvodjac;
                noviProizvedeniProizvod.proizvodnja = trazenaProizvodnja;
                lista.Add(noviProizvedeniProizvod);
            }
            return lista;
        }

        public void IzbrisiProizvod(int IdProizvoda)
        {
            Proizvod izbrisaniProizvod = azilEntities.Proizvods.FirstOrDefault(x => x.idProizvoda == IdProizvoda);
            if (izbrisaniProizvod != null)                                                                                  //ako korisnik unese nepostojeci proizvod
            {
                azilEntities.Proizvods.Remove(izbrisaniProizvod);                                                           //MORA se podesiti cascade delete u SQL bazi, da bi olaksalo stvari
                azilEntities.SaveChanges();
            }
        }

        public void menjajStanjeProizvoda(int idProizvoda, int idProizvodjaca, double kolicina)
        {
            Proizvod izabraniProizvod = azilEntities.Proizvods.FirstOrDefault(x => x.idProizvoda == idProizvoda);
            izabraniProizvod.kolicina += kolicina;
            Proizvodnja izabranaProizvodnja = azilEntities.Proizvodnjas.FirstOrDefault(x => x.idProizvoda == idProizvoda && x.idProizvodjaca == idProizvodjaca);
            if (kolicina > 0)                                           //omogucava smanjivanje proizvoda u azilu bez da se povecavaju kolicine proizvodjacu
            {
                izabranaProizvodnja.dostupneKolicine -= Convert.ToInt32(kolicina);
            }
            azilEntities.SaveChanges();
        }
    }
}