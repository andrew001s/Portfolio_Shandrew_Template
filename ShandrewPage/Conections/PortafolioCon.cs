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

        public async Task<List<Portafolio>> GetByType(string tipo)
        { 
            var filter = Builders<Portafolio>.Filter.Eq(p => p.Tipo, tipo);
            var projection = Builders<Portafolio>.Projection
            .Include(p => p.Id)
            .Include(p => p.nombre)
            .Include(p => p.Tipo)
            .Include(p => p.ruta)
            .Include(p => p.imagen);

            var query = await prod.Find(filter).Project<Portafolio>(projection).ToListAsync();
            
            return query;
        }
        public async Task<List<Portafolio>> GetAll()
        { 
            var projection = Builders<Portafolio>.Projection
            .Include(p => p.Id)
            .Include(p => p.nombre)
            .Include(p => p.Tipo)
            .Include(p => p.ruta)
            .Include(p => p.imagen);

            var query = await prod.Find(_=>true).Project<Portafolio>(projection).ToListAsync();
            
            return query;
        }

    }
}
