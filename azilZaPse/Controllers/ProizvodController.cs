using azilZaPse.Models;
using azilZaPse.Models.Interfejsi;
using azilZaPse.Models.Repository_Ef_Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace azilZaPse.Views
{
    public class ProizvodController : Controller
    {
        private IProizvodInterface RadniProizvod;

        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();

        public ProizvodController()
        {
            RadniProizvod = new ProizvodiRepository();
        }

        public ActionResult Proveri()
        {
            return View();
        }
        public ActionResult Upravljaj()
        {
            List<ProizvedeniProizvodiBO> trazeni = new List<ProizvedeniProizvodiBO>();
            trazeni = RadniProizvod.NadjiProizvod(7).ToList();
            List<ProizvodjacBO> trazeniProizvodjac = new List<ProizvodjacBO>();
            foreach (ProizvedeniProizvodiBO proizvodjac in trazeni)
            {
                trazeniProizvodjac.Add(proizvodjac.proizvodjac);
            }
            ViewBag.Proizvodjac = trazeniProizvodjac;
            return View();
        }

        public ActionResult PrikazStanja(int Id)
        {
            return PartialView("PrikazStanja", RadniProizvod.NadjiProizvod(Id));
        }

        public ActionResult ProizvodProizvodi(int Id)
        {
            return PartialView("ProizvodProizvodi", RadniProizvod.NadjiProizvod(Id));

        }

        public ActionResult izbrisiProizvod(int Id)
        {
            RadniProizvod.IzbrisiProizvod(Id);
            return new EmptyResult();
        }

        public ActionResult menjajStanjeProizvoda(int idProizvoda, int idProizvodjaca, double kolicina)
        {
            RadniProizvod.menjajStanjeProizvoda(idProizvoda, idProizvodjaca, kolicina);
            return new EmptyResult();
        }
    }
}