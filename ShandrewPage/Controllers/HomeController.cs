using Microsoft.AspNetCore.Mvc;
using ShandrewPage.Conections;
using ShandrewPage.Models;
using System.Diagnostics;

namespace ShandrewPage.Controllers
{
    public class HomeController : Controller
    {
        public readonly PortafolioCon db;
        private readonly IEmailService _emailService;

        public HomeController(IConfiguration configuration, IEmailService emailService)
        {
            db= new PortafolioCon(configuration);
            _emailService = emailService;
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
            var port = newPort.Skip(Math.Max(0, newPort.Count - 4)).Select(x => new Portafolio
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
        public IActionResult ContactMe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SendEmail(string Username, string Subject, string Messsage, string to)
        {
            var email = new Email
            {

                EmailAddress = "andresroman45678@gmail.com",
                Subject = Subject + "-" + Username,
                Message = "El usuario:" + Username + "El siguiente mensaje: " + Messsage + "Contactar a: " + to
            };
            _emailService.SendEmail(email);
            return RedirectToAction("Index","Home");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}