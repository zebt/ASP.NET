using System;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET.Models;
using System.Data.Entity;
using ASP.NET.ViewModels;

namespace ASP.NET.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context; // potrzeby jest, aby uzyskac dostep do bazy danych
        public CustomerController()
        {
            _context = new ApplicationDbContext(); // Disposible object - jednorazowy obiekt/

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Nowy()
        {
        var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new FormularzKlienta
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("FormularzKlienta", viewModel);
        }
        [HttpPost]
            public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FormularzKlienta
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("FormularzKlienta", viewModel);
            }
            


                    if (customer.Id == 0)
                        _context.Customers.Add(customer);
                    else	
                    {
                        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                        //var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                        customerInDb.Name = customer.Name;
                        customerInDb.Email = customer.Email;
                         customerInDb.Numer = customer.Numer;
                         customerInDb.Miasto = customer.Miasto;
                         customerInDb.Kod_pocztowy = customer.Kod_pocztowy;
                         customerInDb.Ulica = customer.Ulica;
                         customerInDb.Dom = customer.Dom;
                        customerInDb.MembershipTypeId = customer.MembershipTypeId;
                        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    }	
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Customer");
        }	
        
       
        public ViewResult Index()
        {
            var customers = /*GetCustomers();*/ _context.Customers.Include(c => c.MembershipType).ToList(); 
            // all customers in the database - the third execution

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                 .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edytuj(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            /* blad 404 w przypadku nie znalezienia klienta w bazie */
            if (customer == null)
                
                return HttpNotFound();

            var viewModel = new FormularzKlienta
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("FormularzKlienta", viewModel);
        }

        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }*/
    }
}