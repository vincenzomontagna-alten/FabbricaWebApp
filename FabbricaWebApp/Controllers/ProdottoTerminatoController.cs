using FabbricaWebApp.Data;
using FabbricaWebApp.Data.Repositories;
using FabbricaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FabbricaWebApp.Controllers
{
    public class ProdottoTerminatoController : Controller
    {
        private readonly ProdottoTerminatoRepository _repository;

        public ProdottoTerminatoController(ProdottoTerminatoRepository p)
        {
            _repository = p;
        }

        // GET: /ProdottTerminato/
        public IActionResult Index()
        {
            List<ProdottoTerminato> prodotti = _repository.GetAll();
            return View(prodotti);
        }
    }
}
