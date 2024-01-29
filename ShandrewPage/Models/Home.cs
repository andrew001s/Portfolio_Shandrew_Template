using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShandrewPage.Models
{
    public class Home
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public bool Commissions { get; set; }


    }
}
