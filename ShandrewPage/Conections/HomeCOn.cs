using MongoDB.Driver;
using ShandrewPage.Models;
namespace ShandrewPage.Conections
{
    public class HomeCOn
    {
        private readonly IMongoCollection<Home> home;
        public HomeCOn(IConfiguration configuration)
        {
            var mongo = new DBMongo(configuration);
            home = mongo.GetDatabase().GetCollection<Home>("Home");
        }
        public async Task<List<Home>> ObtenerCommAsync()
        {
            var projection = Builders<Home>.Projection
            .Include(p => p.Commissions)
            .Include(p=>p.Id);
            var query = home.Find(_ => true).Project<Home>(projection).ToListAsync();

            return query.Result;
        }
    }
}
