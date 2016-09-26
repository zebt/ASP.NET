using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET.Models;

namespace ASP.NET.Controllers
{
    public class ProduktyController : Controller
    {
        // GET: Produkty
        public ActionResult Produkty()
        {
            var produkt = new Produkt() { nazwa = "Mąka" };
            return View(produkt);
        }
    }
}