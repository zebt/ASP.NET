
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Nazwa{ get; set; }
        public short SignUpFee { get; set; } // short -  < more than 32000
        public byte DurationInMonths { get; set; } // byte - w naszym przypadku 12 to najwyzsza mozliwa wartosc
        public byte DiscountRate { get; set; }
    }
}