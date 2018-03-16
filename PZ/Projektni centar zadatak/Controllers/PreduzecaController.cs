using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektni_centar_zadatak.Models;
using System.IO;

namespace Projektni_centar_zadatak.Controllers
{
    public class PreduzecaController : Controller
    {
        // GET: Preduzeca
        public ActionResult PrikaziSve()
        {
            var preduzeca = new ProjektniZadatakEntities1();
            return View(preduzeca.Preduzeces.ToList());
        }

        public ActionResult Detalji(int ID)
        {
            ProjektniZadatakEntities1 pred = new ProjektniZadatakEntities1();
            Preduzece Preduzece = pred.Preduzeces.FirstOrDefault(x => x.ID == ID);
            if(Preduzece != null)
            {

                return View(Preduzece);
            }
            return RedirectToAction("PrikaziSve", "Preduzeca");

           
        }
        [HttpPost]
       public ActionResult Obrisi(int ID)
        {

            ProjektniZadatakEntities1 entities = new ProjektniZadatakEntities1();
            Preduzece preduzece = entities.Preduzeces.FirstOrDefault(x => x.ID == ID);
            if (preduzece != null)
            {
                if(preduzece.FotografijaPecata != null)
                {
                    string fullPath = Request.MapPath(preduzece.FotografijaPecata);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                var kontakti = preduzece.KontaktOsobas.ToList();
                foreach (KontaktOsoba k in kontakti)
                {
                    entities.MailKontakts.RemoveRange(k.MailKontakts.ToList());
                    entities.TelefonKontakts.RemoveRange(k.TelefonKontakts.ToList());
                }
                entities.KontaktOsobas.RemoveRange(kontakti);
                entities.Preduzeces.Remove(preduzece);
                entities.SaveChanges();

                return RedirectToAction("PrikaziSve", "Preduzeca");
            }
            return RedirectToAction("PrikaziSve", "Preduzeca");
        }
        #region parcijalniKontakt
        public PartialViewResult PartKontakti(int ID)
        {
            ProjektniZadatakEntities1 pre = new ProjektniZadatakEntities1();
            var kontakti = pre.KontaktOsobas.Where(x => x.IDpreduzeca == ID);

            return PartialView(kontakti.ToList());
        }
        public PartialViewResult PartTelefoni(int ID)
        {
            ProjektniZadatakEntities1 pre = new ProjektniZadatakEntities1();
            var telefoni = pre.TelefonKontakts.Where(x => x.IDKontakt == ID);
            return PartialView(telefoni.ToList());
        }
        public PartialViewResult PartMail(int ID)
        {
            ProjektniZadatakEntities1 pre = new ProjektniZadatakEntities1();
            var mailovi = pre.MailKontakts.Where(x => x.IDKontakt == ID);
            return PartialView(mailovi.ToList());
        }
        #endregion
        
        public ActionResult Dodaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajPreduzece(Preduzece dodajP)
        {
            
            ProjektniZadatakEntities1 pred = new ProjektniZadatakEntities1();
            if (dodajP.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(dodajP.ImageFile.FileName);

                string ext = Path.GetExtension(dodajP.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + ext;
                dodajP.FotografijaPecata = "~/Images/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/") + fileName);
                dodajP.ImageFile.SaveAs(fileName);
            }
            pred.Preduzeces.Add(dodajP);
            pred.SaveChanges();
            
           
            
            return RedirectToAction("PrikaziSve", "Preduzeca");
        }
        public ActionResult MenadzmentKontakt(int ID)
        {
            ProjektniZadatakEntities1 preduzece = new ProjektniZadatakEntities1();
            Preduzece pr = preduzece.Preduzeces.FirstOrDefault(x => x.ID == ID);
            if (pr != null)
            {
                TempData["NazivPreduzeca"] = preduzece.Preduzeces.Where(x => x.ID == ID).FirstOrDefault().NazivPreduzeca;
                TempData["ID"] = ID;

                return View(pr.KontaktOsobas.ToList());
            }
            return RedirectToAction("PrikaziSve", "Preduzeca");
        }
        [HttpPost]
       public ActionResult IzmeniPreduzece(Preduzece preduzece)
        {
            return View(preduzece);

           
        }
        public ActionResult SnimiIzmene(Preduzece pred)
        {
            ProjektniZadatakEntities1 entities1 = new ProjektniZadatakEntities1();
            Preduzece preduzece = entities1.Preduzeces.FirstOrDefault(x => x.ID == pred.ID);
            if(preduzece != null)
            {
                preduzece.NazivPreduzeca = pred.NazivPreduzeca;
                preduzece.MatBR = pred.MatBR;
                preduzece.Adresa = pred.Adresa;
                preduzece.BrojRacuna = pred.BrojRacuna;
                preduzece.PIB = pred.PIB;
                preduzece.Opstina = pred.Opstina;
                preduzece.PostanskiBR = pred.PostanskiBR;
                preduzece.WebStranica = pred.WebStranica;
                preduzece.Beleska = pred.Beleska;
                entities1.SaveChanges();
                return RedirectToAction("PrikaziSve", "Preduzeca");
            }
            return RedirectToAction("Greska", "Home");
        }
    }
}