using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value= x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.deger = value;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            p.Durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var value = c.Uruns.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            var values = c.Uruns.Find(id);
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.deger = value;
            return View(values);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun p)
        {
            var value = c.Uruns.Find(p.UrunID);
            value.UrunAd = p.UrunAd;
            value.KategoriID = p.KategoriID;
            value.Marka = p.Marka;
            value.Stok = p.Stok;
            value.AlisFiyat = p.AlisFiyat;
            value.SatisFiyat = p.SatisFiyat;
            value.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}