using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET.Models;

namespace ASP.NET.ViewModels
{
    public class RandomKsiazkaViewModel
    {
        // 
        public Ksiazka Ksiazka { get; set; }
        public List<Customer> Customers { get; set; }
    }
}