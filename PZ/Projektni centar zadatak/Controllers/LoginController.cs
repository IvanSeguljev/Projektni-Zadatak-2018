using Projektni_centar_zadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projektni_centar_zadatak.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authorize(Projektni_centar_zadatak.Models.LoginUser korisnik)
        {
            using (ProjektniZadatakEntities pze = new ProjektniZadatakEntities())
            {
                var details = pze.LoginUsers.Where(x => x.Username == korisnik.Username && x.Password == korisnik.Password).FirstOrDefault();
                if (details == null)
                {
                    korisnik.LoginError = "Pogresna lozinka ili nepostojece korisnicko ime";
                    return View("Index", korisnik);
                }
                else
                {
                    Session["PravoPristupa"] = details.PravoPristupa;
                    Session["Username"] = details.Username;
                    return RedirectToAction("Index", "Home");
                }
            }


            
                
        }
        

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}