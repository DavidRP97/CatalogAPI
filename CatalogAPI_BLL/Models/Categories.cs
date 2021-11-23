using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogAPI_BLL.Models
{
    public class Categories
    {
        public Categories()
        {
            Products = new Collection<Product>();
        } 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        [BsonRequired]        
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
