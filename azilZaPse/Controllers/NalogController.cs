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
    public class NalogController : Controller
    {
        private IAuthInterface authRepository = new AuthRepository();
        // GET: Nalog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KorisnikBO korisnik)
        {
            if(authRepository.DaLiJeValidno(korisnik))
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
            return RedirectToAction("Index", "Home");
        }
    }
}