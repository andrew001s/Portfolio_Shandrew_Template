using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShandrewPage.Models
{
    public class Services
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
