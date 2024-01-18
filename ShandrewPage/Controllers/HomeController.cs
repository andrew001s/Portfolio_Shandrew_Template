using Microsoft.AspNetCore.Mvc;
using ShandrewPage.Conections;
using ShandrewPage.Models;
using System.Diagnostics;

namespace ShandrewPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly PortafolioCon db;
        public HomeController(IConfiguration configuration)
        {
            db= new PortafolioCon(configuration);
        }
      

        public IActionResult Index()
        {
            var portafolio = listar().Result;
            return View(portafolio);
        }
        [HttpGet]
        public async Task<List<Portafolio>> listar()
        {
            List<Portafolio> newPort = await db.ObtenerPortafolioAsync();
            var port = newPort.Take(4).Select(x => new Portafolio
            {
                Id = x.Id,
                nombre = x.nombre,
                Tipo = x.Tipo,
                imagen = x.imagen
            }).ToList();
            return port;
        }
        public IActionResult About_Me()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}