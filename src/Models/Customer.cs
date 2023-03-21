using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinimalAPIS.Models
{
    public class Customer
    {
        public long Id {get; set; }

        [Required]
        public string Firstname {get; set; }

        [Required]
        public string Lastname {get; set; }

        [Required]
        public string Email {get; set;}
        //Propriété Navigation de Collection vers Product
        public List<Product> Products {get; set;} 
        

    }
}