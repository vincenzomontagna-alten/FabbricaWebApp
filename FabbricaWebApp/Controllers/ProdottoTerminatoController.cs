


namespace FabbricaWebApp.Controllers
{
    public class ProdottoTerminatoController : Controller
    {
        //private readonly IProdottoTerminatoRepositoryInterface _repository;

        public ProdottoTerminatoController(/*IProdottoTerminatoRepositoryInterface p*/)
        {
            //_repository = p;
        }

        // GET: /ProdottTerminato/ uso la dependency injection nel metodo anzichè nel costruttore
        public IActionResult Index([FromServices] IProdottoTerminatoRepositoryInterface _repository)
        {       
            List<ProdottoTerminato> prodotti = _repository.GetAll();
            foreach (var prodotto in prodotti)
            {
                prodotto.Quantita = 1;
                if (!TryValidateModel(prodotto))
                {
                    return BadRequest(ModelState);
                }
            }
            return View(prodotti);
        }
    }
}
