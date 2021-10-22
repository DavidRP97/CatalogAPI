using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_BLL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public Categories Category { get; set; }
        public int CategoryId { get; set; }
    }
}
