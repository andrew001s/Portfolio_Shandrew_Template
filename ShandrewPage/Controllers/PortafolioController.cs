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
        public readonly PaginatedResult<Portafolio> _paginatedResult;
        public PortafolioController(IConfiguration configuration, PaginatedResult<Portafolio> paginatedResult)
        {
            db= new PortafolioCon(configuration);
            _paginatedResult=paginatedResult;
        }

        [Route("Portafolio/Index/{tipo?}/{page?}")]
        public ActionResult Index(int page=1,string tipo="Avatar")
        {
            var portafolioAvatares= listar(page,tipo).Result;
            ViewData["tipo"]=tipo;
            ViewData["portafolio"]=portafolioAvatares;
            ViewData["page"]=page;
            return View();
        }
        [HttpGet]
        public async Task<PaginatedResult<Portafolio>> listar(int pageNumber=1, string tipo="Avatar", int PageSize = 8)
        {
            var portafolio= await db.GetByType(tipo);
            int totalRecord = portafolio.Count();
            int totalPage = (int)Math.Ceiling(totalRecord / (double)PageSize);
            var paginatedModels = (from m in portafolio
                                   orderby m.Id descending
                                   select m).Skip((pageNumber-1)*PageSize).Take(PageSize);
            

            return new PaginatedResult<Portafolio>
            {
                Items = paginatedModels,
                totalPage = totalPage,
                totalRecord = totalRecord
            };
        } 
       
    }
}
