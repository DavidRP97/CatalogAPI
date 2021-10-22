using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_BLL.Models
{
    public class Categories
    {
        public Categories()
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
