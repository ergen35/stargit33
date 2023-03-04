using System.ComponentModel.DataAnnotations;

namespace MinimalAPIS.Models
{
    public class ProductInfo 
    {
        [Key]
        public int ProductID { get; set; }
        public string Description { get; set; }
        public  Product Product {get; set; }
    }

}