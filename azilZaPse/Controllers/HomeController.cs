using azilZaPse.Models;
using azilZaPse.Models.Interfejsi;
using azilZaPse.Models.Repository_Ef_Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace azilZaPse.Controllers
{
    public class HomeController : Controller
    {
        private IAuthInterface authRepository = new AuthRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(KorisnikBO korisnik)
        {
            if (authRepository.DaLiJeValidno(korisnik))
            {
                FormsAuthentication.SetAuthCookie(korisnik.KorisnickoIme, false);
                return RedirectToAction("Index", "Radna");
            }
            ModelState.AddModelError("", "Uneti podaci nisu validni");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KorisnikBO korisnik)
        {
            authRepository.DodajKorisnika(korisnik);
            return RedirectToAction("Login");
        }
    }
}