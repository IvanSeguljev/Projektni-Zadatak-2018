using Projektni_centar_zadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Projektni_centar_zadatak;

namespace Projektni_centar_zadatak.Controllers
{
    public class AdministracijaController : Controller
    {

        // GET: Administracija
        public ActionResult VratiKorisnike()
        {

            var korisnici = new ProjektniZadatakEntities();
            return View(korisnici.LoginUsers.ToList());

        }
        [HttpPost]
        public ActionResult Obrisi(string id)
        {

            ProjektniZadatakEntities entities = new ProjektniZadatakEntities();
            LoginUser korisnik = entities.LoginUsers.FirstOrDefault(x => x.Username == id);
            if (korisnik != null)
            {
                entities.LoginUsers.Remove(korisnik);
                entities.SaveChanges();
            }

            return RedirectToAction("VratiKorisnike", "Administracija");
        }
        
        public ActionResult Dodaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajNovog(LoginUser Novi)
        {
            ProjektniZadatakEntities entities = new ProjektniZadatakEntities();
            LoginUser duplikat = entities.LoginUsers.FirstOrDefault(x => x.Username == Novi.Username);
            if (duplikat == null)
            {
                entities.LoginUsers.Add(Novi);
                entities.SaveChanges();
                return RedirectToAction("Dodaj");
            }
            else
            {
                TempData["msg"] = "<script>alert('Korisnik sa istim korisnickim imenom vec postoji!');</script>";
                return View("Dodaj",Novi);
            }
        }

       

        public ActionResult Izmeni(string id)
        {
            
            ProjektniZadatakEntities entities = new ProjektniZadatakEntities();
            LoginUser user = entities.LoginUsers.FirstOrDefault(x => x.Username == id);
            if (user != null)
            {
                return View("Izmeni", user);
            }
            else
            {
                return RedirectToAction("VratiKorisnike", "Administracija");
            }
        }
        [HttpPost]
        public ActionResult SnimiIzmene(LoginUser user)
        {
             ProjektniZadatakEntities entities = new ProjektniZadatakEntities();
             LoginUser login = entities.LoginUsers.FirstOrDefault(x => x.Username == user.Username);
             if(login != null)
                {
                    
                  login.Password = user.Password;
                  login.PravoPristupa = user.PravoPristupa;
                  entities.SaveChanges();
                    
                }

             return RedirectToAction("VratiKorisnike");
           
        }
    }
}