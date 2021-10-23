using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Caris.Where(x=>x.CariDurum==true).ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult CariEkle(Cari p)
        {
            p.CariDurum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var value = c.Caris.Find(id);
            value.CariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var values = c.Caris.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cari p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGuncelle");
            }
            var value = c.Caris.Find(p.CariID);
            value.CariAd = p.CariAd;
            value.CariSoyad = p.CariSoyad;
            value.CariDurum = p.CariDurum;
            value.CariMail = p.CariMail;
            value.CariSehir = p.CariSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatısGecmis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var prs = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.prs = prs;
            return View(values);
        }
    }
}