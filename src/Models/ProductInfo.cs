using System.ComponentModel.DataAnnotations;

namespace MinimalAPIS.Models
{
    public class ProductInfo 
    {
        
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProductId {get; set;}
        public  Product Product {get; set; }

    }

}