using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET.Models;
using ASP.NET.ViewModels;
using System.Data.Entity;
using ASP.NET.Migrations;

namespace ASP.NET.Controllers
{
    public class KsiazkiController : Controller
    {

        private ApplicationDbContext _context; // potrzeby jest, aby uzyskac dostep do bazy danych
        public KsiazkiController()
        {
            _context = new ApplicationDbContext(); // Disposible object - jednorazowy obiekt/

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Ksiazki: Ksiazki/Random


        public ViewResult Index()
        {
            var ksiazki = _context.Ksiazkas.Include(m => m.Gatunek).ToList();

            return View(ksiazki);
        }

        public ViewResult Nowa()
        {
            var gatunki = _context.Gatunki.ToList();

            var viewModel = new FormularzKsiazki
            {
                Gatunki = gatunki
            };

            return View("FormularzKsiazki", viewModel);
        }

        public ActionResult Edytuj(int id)
        {
            var ksiazka = _context.Ksiazkas.SingleOrDefault(c => c.Id == id);

            if (ksiazka == null)
                return HttpNotFound();

            var viewModel = new FormularzKsiazki
            {
                Ksiazka = ksiazka,
                Gatunki = _context.Gatunki.ToList()
            };

            return View("FormularzKsiazki", viewModel);
        }


        public ActionResult Details(int id)
        {
            var ksiazka = _context.Ksiazkas.Include(m => m.Gatunek).SingleOrDefault(m => m.Id == id);

            if (ksiazka == null)
                return HttpNotFound();

            return View(ksiazka);

        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var ksiazka = new Ksiazka() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomKsiazkaViewModel
            {
                Ksiazka = ksiazka,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Zapisz(Ksiazka ksiazka)
        {
            
            
            
            if (ksiazka.Id == 0)
            {

               /* ksiazka.DateAdded = DateTime.Now;*/
                _context.Ksiazkas.Add(ksiazka);
            }
            else
            {
                var ksiazkaInDb = _context.Ksiazkas.Single(m => m.Id == ksiazka.Id);
                ksiazkaInDb.Name = ksiazka.Name;
                ksiazkaInDb.GatunekId = ksiazka.GatunekId;
               
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Ksiazki");
        }
    }
}


        /*private IEnumerable<Ksiazka> GetKsiazki()
        {
            return new List<Ksiazka>
            {
                new Ksiazka { Id = 1, Name = "Shrek" },
                new Ksiazka { Id = 2, Name = "Wall-e" }
            };
        }*/








        /*

        public ActionResult Random()
        {
            var Ksiazka = new Ksiazka() { Name = "Shrek!" };
            var customers = new List<Customer> //dodajemy dwa obiekty klienta
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomKsiazkaViewModel
            {
                Ksiazka = Ksiazka,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); // Index - nazwa akcji, Home - controler, obiekt - page (Argumenty)

        }
        public ActionResult Edit(int id) // int id zmieniamy na KsiazkaId
        {
            return Content("id=" + id); // + id zamieniamy na + KsiazkaId --> /Ksiazki/Edit/?KsiazkaId=1
        }

        // Ksiazki

       
        public ActionResult Index(int? pageIndex, string sortBy) // list of Ksiazki from database sort by name, int? - parametr opcjonalny
        {
            if (!pageIndex.HasValue)
                pageIndex = 1; // wywołanie /Ksiazki?pageIndex spowoduje przekazanie parametru 1 
                               // oczywiscie dzieki negacji, mozemy wywołać inny parametr
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("Ksiazki/released/{year}/{month:regex(\\d{2}):range(1,12)}")] // d - oznacza digit, to nie jest string wiec backslash musi zostac 2 razy napisany
       // mamy jeszcze inne stałe, np. min, max, minlength, maxlength, int, float, guid
            
            public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
       
        */

           
