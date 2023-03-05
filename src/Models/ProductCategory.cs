
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPIS.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string NameCategory { get; set; }

        //Propriété Navigation de Collection vers Product
        public List<Product> Product  {get; set;}

    }
}