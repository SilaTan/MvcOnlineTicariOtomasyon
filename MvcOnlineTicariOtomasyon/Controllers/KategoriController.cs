using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Kategoris.ToList();
            return View(values);
        }
        
        [HttpPost]
        public ActionResult KategoriEkle(Kategori p)
        {
            c.Kategoris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var value=c.Kategoris.Find(id);
            c.Kategoris.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var values = c.Kategoris.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori p)
        {
            var value = c.Kategoris.Find(p.KategoriID);
            value.KategoriAd = p.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}