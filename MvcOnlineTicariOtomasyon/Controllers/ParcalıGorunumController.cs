using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ParcalıGorunumController : Controller
    {
        Context c = new Context();
        public PartialViewResult DepartmanListesi()
        {
            var value = c.Departmans.Where(x => x.DepartmanDurum == true).ToList();
            return PartialView(value);
        }
    }
}