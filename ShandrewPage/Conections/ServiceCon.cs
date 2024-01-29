using MongoDB.Driver;
using ShandrewPage.Models;
namespace ShandrewPage.Conections
{
    public class ServiceCon
    {
        private readonly IMongoCollection<Services> service;
        public ServiceCon(IConfiguration configuration)
        {
            var mongo = new DBMongo(configuration);
            service = mongo.GetDatabase().GetCollection<Services>("Services");
        }
        public async Task<List<Services>> ObtenerServiciosAsync()
        {
            var projection = Builders<Services>.Projection
            .Include(p => p.Id)
            .Include(p => p.Type)
            .Include(p => p.Name)
            .Include(p => p.Price)
            .Include(p => p.Description);
            var query = service.Find(_ => true).Project<Services>(projection).ToListAsync();

            return query.Result;
        }
    }
}
