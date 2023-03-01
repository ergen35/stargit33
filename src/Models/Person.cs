using System.ComponentModel.DataAnnotations;

namespace MinimalAPIS.Models
{
    public class Person
    {
        public long Id {get; set; }

        [Required]
        public string firstname {get; set; }

        [Required]
        public string lastname {get; set; }

        [Required]
        public string email {get; set;}
    }
}