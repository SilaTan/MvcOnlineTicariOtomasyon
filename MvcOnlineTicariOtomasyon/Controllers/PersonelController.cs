using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Personels.ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var values = c.Personels.Find(id);
            List<SelectListItem> dprt = (from x in c.Departmans.Where(x=>x.DepartmanDurum==true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.deger = dprt;
            return View(values);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel p)
        {
            var value = c.Personels.Find(p.PersonelID);
            value.PersonelAd = p.PersonelAd;
            value.PersonelSoyad = p.PersonelSoyad;
            value.PersonelGorsel = p.PersonelGorsel;
            value.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}