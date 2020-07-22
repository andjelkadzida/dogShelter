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
    public class PasController : Controller
    {
        private IKuceInterface RadnoKuce;

        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();

        public PasController()
        {
            RadnoKuce = new KuceRepository();
        }
        public ActionResult Dodaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dodaj(KuceBO novoKuce)
        {
            if (novoKuce.ProveraValidnosti())
            {
                RadnoKuce.Dodaj(novoKuce);
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult Pregledaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pregledaj(KartonPsaBO kartonPsa)
        {
            if (kartonPsa.ProveraValidnosti())                                     //mozda tehnicki nepotrebno zbog javascript provere ali za svaki slucaj
            {
                RadnoKuce.UpdateKartona(kartonPsa);
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult Udomi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Udomi(KuceBO kuce)
        {
            RadnoKuce.Udomi(kuce.IdCipa);
            ModelState.Clear();
            return View();
        }
        public ActionResult Trazi()
        {
            return View();
        }

        public ActionResult NadjiKucePoParametrima(int starost, string rasa, string pol)
        {
            if (starost == 0)
                starost = 0;

            if (String.IsNullOrEmpty(rasa))
                rasa = "";

            if (String.IsNullOrEmpty(pol))
                pol = "";

            return PartialView("NadjiKucePoParametrima", RadnoKuce.NadjiKucePoParametrima(starost, rasa, pol));
        }
    }
}