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
    }
}