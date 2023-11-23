using MongoDB.Driver;
using ShandrewPage.Models;

namespace ShandrewPage.Conections
{
    public class PortafolioCon
    {
        private readonly IMongoCollection<Portafolio> prod;
        public PortafolioCon(IConfiguration configuration)
        {
            var mongo = new DBMongo(configuration);
            prod = mongo.GetDatabase().GetCollection<Portafolio>("portafolio");
        }

        public List<Portafolio> ObtenerPortafolio()
        {
            {
                var query = prod.Find(_ =>true).ToListAsync();
                return query.Result;
            }
        }
    }
}
