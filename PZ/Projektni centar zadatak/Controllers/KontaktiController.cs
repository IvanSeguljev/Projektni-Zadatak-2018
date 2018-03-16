using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektni_centar_zadatak.Models;

namespace Projektni_centar_zadatak.Controllers
{
    public class KontaktiController : Controller
    {
        #region ParcijalniPregledi
        // GET: Kontakti
        public PartialViewResult MailLista(KontaktOsoba kontakt)
        {

            return PartialView(kontakt.MailKontakts.ToList());
        }

        public PartialViewResult TelefonLista(KontaktOsoba kontakt)
        {
            TempData["ID"] = kontakt.ID.ToString();
            return PartialView(kontakt.TelefonKontakts.ToList());
        }
        #endregion
        #region DodavanjeUBazu
        [HttpPost]
        public ActionResult DodavanjeTelefona(TelefonKontakt tel)
        {

            
            ProjektniZadatakEntities1 entities = new ProjektniZadatakEntities1();
            KontaktOsoba kontos = entities.KontaktOsobas.FirstOrDefault(x => x.ID == tel.IDKontakt);
            if (kontos != null)
            {
                TelefonKontakt duplikat = entities.TelefonKontakts.FirstOrDefault(x => x.BrojTelefona == tel.BrojTelefona);
                if (duplikat == null)
                {
                    entities.TelefonKontakts.Add(tel);
                    entities.SaveChanges();
                    return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontos.IDpreduzeca });
                }
                else
                {
                   
                    duplikat.Greska = true;
                    TempData["msg"] = "Isti broj telefona vec postoji!";
                    return View("DodajBroj", duplikat);
                   
                }
            }
            else
            {
                return RedirectToAction("Greska", "Home");
            }
        }

        [HttpPost]
        public ActionResult DodavanjeMaila(MailKontakt mail)
        {

            ProjektniZadatakEntities1 entities = new ProjektniZadatakEntities1();
            
            KontaktOsoba kontos = entities.KontaktOsobas.FirstOrDefault(x => x.ID == mail.IDKontakt);
            
            if (kontos != null)
            {
                MailKontakt duplikat = entities.MailKontakts.FirstOrDefault(x => x.Adresa == mail.Adresa);
                if (duplikat == null)
                {
                    entities.MailKontakts.Add(mail);
                    entities.SaveChanges();
                    return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontos.IDpreduzeca });
                }
                else
                {
                    duplikat.Greska = true;
                    TempData["msg"] = "Ista mail adresa vec postoji!";
                    return View("DodajMail", duplikat);
                }
            }
            else
            {
                return RedirectToAction("Greska", "Home");
            }
            
           
        }
        [HttpPost]
        public ActionResult DodavanjeKontaktOsobe(KontaktOsoba kontos)
        {
            ProjektniZadatakEntities1 entities1 = new ProjektniZadatakEntities1();
            Preduzece preduzece = entities1.Preduzeces.FirstOrDefault(x => x.ID == kontos.IDpreduzeca);
            if (preduzece != null)
            {
                entities1.KontaktOsobas.Add(kontos);
                entities1.SaveChanges();
                return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontos.IDpreduzeca });
            }
            else
            {
                return RedirectToAction("Greska", "Home");
            }
        }
       
        #endregion
        #region DodavanjePregledi
         public ActionResult DodajKontaktOsobu(int ID)
        {
            KontaktOsoba kontakt = new KontaktOsoba();
            kontakt.IDpreduzeca = ID;
            return View(kontakt);
        }
        public ActionResult DodajMail(KontaktOsoba kont)
        {
            MailKontakt Mail = new MailKontakt();
            Mail.IDKontakt = kont.ID;
            Mail.KontaktOsoba = kont;
            return View(Mail);
        }
       
        public ActionResult DodajBroj(KontaktOsoba kont)
        {
            TelefonKontakt telefon = new TelefonKontakt();
            telefon.IDKontakt = kont.ID;
            telefon.KontaktOsoba = kont;
            return View(telefon);
        }
        #endregion
        #region Brisanje
        [HttpPost]

        public ActionResult ObrisiMail(MailKontakt mail)
        {
            
            ProjektniZadatakEntities1 entities1 = new ProjektniZadatakEntities1();
            KontaktOsoba kontos = entities1.KontaktOsobas.FirstOrDefault(x => x.ID == mail.IDKontakt);
            MailKontakt t = entities1.MailKontakts.FirstOrDefault(x => x.Adresa == mail.Adresa);
            if (t != null)
            {
                entities1.MailKontakts.Remove(t);
                entities1.SaveChanges();
                
            }
            if (kontos != null)
            {
                return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontos.IDpreduzeca });
            }
            else
                return RedirectToAction("Greska", "Home");
        }
        [HttpPost]
        public ActionResult ObrisiTelefon(TelefonKontakt telefon)
        {

            ProjektniZadatakEntities1 entities1 = new ProjektniZadatakEntities1();
            KontaktOsoba kontos = entities1.KontaktOsobas.FirstOrDefault(x => x.ID == telefon.IDKontakt);
            TelefonKontakt t = entities1.TelefonKontakts.FirstOrDefault(x => x.BrojTelefona == telefon.BrojTelefona);
            if (t != null)
            {
               
                entities1.TelefonKontakts.Remove(t);
                entities1.SaveChanges();
                
            }
            if (kontos != null)
            {
                return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontos.IDpreduzeca });
            }
            else
            {
                return RedirectToAction("Greska", "Home");
            }

        }
        [HttpPost]
        public ActionResult ObrisiKontaktOsobu(KontaktOsoba kontakt)
        {

            ProjektniZadatakEntities1 entities1 = new ProjektniZadatakEntities1();
            KontaktOsoba kontos = entities1.KontaktOsobas.FirstOrDefault(x => x.ID == kontakt.ID);
            if (kontos != null)
            {
                
                entities1.MailKontakts.RemoveRange(kontos.MailKontakts.ToList());
                entities1.TelefonKontakts.RemoveRange(kontos.TelefonKontakts.ToList());
                entities1.KontaktOsobas.Remove(kontos);
                entities1.SaveChanges();
               
            }
            return RedirectToAction("MenadzmentKontakt", "Preduzeca", new { id = kontakt.IDpreduzeca });

        }
        #endregion
    }
}