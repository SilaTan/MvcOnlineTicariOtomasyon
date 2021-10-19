using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Departmans.Where(x=>x.DepartmanDurum==true).ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            p.DepartmanDurum = true;
            c.Departmans.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var value = c.Departmans.Find(id);
            value.DepartmanDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var values = c.Departmans.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var value = c.Departmans.Find(p.DepartmanID);
            value.DepartmanAd = p.DepartmanAd;
            value.DepartmanDurum = p.DepartmanDurum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var value = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dprt = c.Departmans.Where(x => x.DepartmanID == id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.dprt = dprt;
            return View(value);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var value = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var prs = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.prs = prs;
            return View(value);
        }
    }
}