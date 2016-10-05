using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }
     

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Gatunek Gatunek { get; set; }

        [Display(Name = "Gatunek")]
        [Required]
        public byte GatunekId { get; set; }

        public DateTime DateAdded { get; set; }
    }

    // /Ksiazki/random

}

