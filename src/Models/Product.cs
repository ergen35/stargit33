using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPIS.Models
{
    public class Product
    {

        public int  ID{ get; set; }
        //propriété clé étrangère vers Customer
        public long CustomerId { get; set; }
        // propriété clé étrangère vers  ProductCatégorie
        public int ProductCategoryId {get; set; }

        [Required]
        public string  NameProduct { get; set; }

        [Required]
        public double Price { get; set; }

        public int Quantity { get; set; }

        //Propriété Navigation de référence vers Custumer
        public Customer Customer {get; set; }
        //Propriété Navigation de référence vers ProductCategory
        public ProductCategory ProductCategory {get; set; }
        public ProductInfo ProductInfo { get; set;}
    }
}