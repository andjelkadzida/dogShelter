using azilZaPse.Models;
using azilZaPse.Models.Interfejsi;
using azilZaPse.Models.Repository_Ef_Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace azilZaPse.Controllers
{
    public class DokumentacijaController : Controller
    {
        // GET: IzdavanjeDokumentacije
        private IDokumentacijaInterface RadnaDokumentacija;

        public KuceRepository RadnoKuce { get; }

        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();


        public DokumentacijaController()
        {
            RadnaDokumentacija = new DokumentacijaRepository();
            RadnoKuce = new KuceRepository();
        }

        public ActionResult Izdaj()
        {
            ViewBag.Kuce = RadnoKuce.KuciciUAzilu();
            return View();
        }
        [HttpPost]
        public ActionResult Izdaj(DodajDokumentacijuBO NovaDokumentacija)
        {
            NovaDokumentacija.dokumentacija.IdVlasnika = NovaDokumentacija.vlasnik.IdVlasnika;     //Posto imamo samo jedan input za ID ovo kopira id u dokumentaciju
            if (NovaDokumentacija.vlasnik.ProveraValidnosti() && NovaDokumentacija.dokumentacija.ProveraValidnosti())        
            {
                var item = azilEntities.Vlasniks.FirstOrDefault(x => x.idVlasnika == NovaDokumentacija.vlasnik.IdVlasnika);  //Dodati vlasnika samo ako ne postoji
                if (item == null)
                {
                    RadnaDokumentacija.DodajVlasnika(NovaDokumentacija.vlasnik);
                }
                RadnaDokumentacija.DodajDokumentaciju(NovaDokumentacija.dokumentacija);
            }
            ModelState.Clear();
            ViewBag.Kuce = RadnoKuce.KuciciUAzilu();                                                                        //Bez ovoga doda se sve kako treba
            return View();                                                                                                  //ali program puca
        }
        public ActionResult Pretraga()
        {
            return View();
        }

        public ActionResult NadjiDokumentaciju(string idVlasnika)
        {

            return PartialView("NadjiDokumentaciju", RadnaDokumentacija.NadjiDokumentaciju(idVlasnika));
        }
    }
}