using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP.NET.Models;
using ASP.NET.Dtos;
using AutoMapper;


namespace ASP.NET.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);       
        }

        //GET /api/customers/id
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            
                //jezeli dany zasób nie został znaleziony, zwróć standardową Not found odpowiedź Http
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST /api/customers
        // tworzymy w tym momencie nowy zasób, akcja bedzie wywołana tylko wtedy, kiedy będziemy chcieli utworzyć klienta
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto; // zwracamy obiekt wypozyczajacego    
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id); //DB Context ma możliwość śledzenia zmian w obiekcie Dto
            //possible that client sent invalid id, check the existance of object
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); // drugi argument jest inny w tej metodzie -  nowy obiekt i zwracam go
            // obiekt ładowany jest do contextu 

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();   
        }        
    }
}
