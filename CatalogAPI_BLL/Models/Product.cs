using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System;

namespace CatalogAPI_BLL.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        [BsonRequired]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public Categories Category { get; set; }
    }
}
