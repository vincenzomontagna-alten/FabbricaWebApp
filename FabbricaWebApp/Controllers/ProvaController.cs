using FabbricaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace FabbricaWebApp.Controllers
{
    

    public class ProvaController : Controller
    {
        
        public ActionResult Index([FromServices] ConfigurationManager configuration)
        {
            ProdottoTerminato p = new ProdottoTerminato();
            p.Id = 3;
            p.Quantita = 3;
            p.NomeProdotto = "Prova";
            var a = TryValidateModel(p);
            var x = configuration.GetValue<string>("MyCustomKey");
            return Content(x);
        }

        
        [Route("Prova/Prova/{id}&{nomeprodotto}&{quantita}")]
        public ActionResult Prova(int id, string nomeProdotto, int quantita)
        {  
            ProdottoTerminato prodotto = new ProdottoTerminato();
            prodotto.Id = id;
            prodotto.Quantita = quantita;
            prodotto.NomeProdotto = nomeProdotto;
            if (TryValidateModel(prodotto))
            {
                return Json(prodotto);
            }
            else
            {
                return Content("I dati inseriti non sono validi");
            }
        }

        [Route("Prova/Prova2/{a}")]
        public ActionResult Prova2(string a)
        {
            return Content($"Il parametro è: {a}");
        }

        [Route("Prova/Prova3/{a}")]
        public string Prova3(string a)
        {
            return $"Il parametro è: {a}";
        }

        [Route("Prova/PostProduct")]
        [HttpPost]
        public ActionResult PostProduct([FromBody]ProdottoTerminato p)
        {
            if (ModelState.IsValid)
            {
                return Json(p);
            }
            else 
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> CallApi([FromServices]HttpClientTest test)
        {
            string jsonRespose = await test.CallApi();
            return Content(jsonRespose);
        }


    }
}
