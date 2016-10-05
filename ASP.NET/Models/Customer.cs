using System;
using System.ComponentModel.DataAnnotations;


namespace ASP.NET.Models
{
    public class Customer
    {
        public int Id { get; set; }
        // dzieki temu nasze pole name nie moze byc puste
        [Required(ErrorMessage = "Proszę, wprowadź imię i nazwisko wypożyczającego.")] //data annotation, attribute -> dodac using System.ComponentModel.DataAnnotations
        [StringLength(100)]
        //[RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Niepoprawne imię i nazwisko")]
      
        public string Name { get; set; }
       
        public string Email { get; set; }
        
        public string Numer { get; set; }
   
        public string Miasto { get; set; }
        
        public string Kod_pocztowy { get; set; }
        
        public string Ulica { get; set; }
      
        public string Dom { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

       /* public System.Data.Entity.DbSet<Customer> Customers { get; set; }*/
    }
}