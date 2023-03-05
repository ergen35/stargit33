using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalAPIS.Models
{
    public class Product
    {

        public int  Id{ get; set; }
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
        [JsonIgnore]
        public Customer Customer {get; set; }
        //Propriété Navigation de référence vers ProductCategory
        [JsonIgnore]
        public ProductCategory ProductCategory {get; set; }
        [JsonIgnore]
        public ProductInfo ProductInfo { get; set;}
    }
}