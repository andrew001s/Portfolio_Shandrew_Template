using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShandrewPage.Conections;
using ShandrewPage.Models;
namespace ShandrewPage.Controllers
{
    public class ServicesController : Controller
    {
        public readonly ServiceCon serv;

        public ServicesController(IConfiguration configuration)
        {
            serv = new ServiceCon(configuration);
        }
        // GET: ServicesController
        public ActionResult Index()
        {
            var services = listar().Result;
            return View(services);
            
        }
        [HttpGet]
        public async Task<List<Services>> listar()
        {
            List<Services> newServ = await serv.ObtenerServiciosAsync();
            var port = newServ.Select(x => new Services
            {
                Id = x.Id,
                Type = x.Type,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description
            }).ToList();
            return port;
        }
        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
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

        // GET: ServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicesController/Edit/5
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

        // GET: ServicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicesController/Delete/5
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
