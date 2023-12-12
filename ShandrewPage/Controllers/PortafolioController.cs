using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShandrewPage.Conections;
using ShandrewPage.Models;

namespace ShandrewPage.Controllers
{
    public class PortafolioController : Controller
    {
        // GET: PortafolioController
        public readonly PortafolioCon db;
        public PortafolioController(IConfiguration configuration)
        {
            db= new PortafolioCon(configuration);
        }
        public ActionResult Index()
        {
            var portafolio= listar();
            return View(portafolio);
        }
        [HttpGet]
        public List<Portafolio> listar()
        {
            List<Portafolio> newPort;

            newPort= db.ObtenerPortafolio();
            var port= newPort.Select(x => new Portafolio{
                Id=x.Id,
                nombre=x.nombre,
                Tipo=x.Tipo,
                imagen=x.imagen
            }).ToList();
            return port;
        } 
        // GET: PortafolioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PortafolioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortafolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortafolioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PortafolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortafolioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PortafolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
