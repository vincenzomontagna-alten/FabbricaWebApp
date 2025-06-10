using FabbricaWebApp.Data.Repositories.RepositoriesInterfaces;
using FabbricaWebApp.Models;

namespace FabbricaWebApp.Data.Repositories
{
    public class ProdottoTerminatoRepository2 : IProdottoTerminatoRepositoryInterface
    {
        private readonly FabbricaDbContext _context;

        public ProdottoTerminatoRepository2(FabbricaDbContext context)
        {
            _context = context; // Usa OnConfiguring per la connessione
        }

        public List<ProdottoTerminato> GetAll()
        {
            Console.WriteLine("Sto facendo la getall");
            return _context.ProdottiTerminati.ToList();
        }

        public ProdottoTerminato? GetById(int id)
        {
            Console.WriteLine("Sto facendo la getbyid");
            return _context.ProdottiTerminati.Find(id);
        }

        public void Add(ProdottoTerminato prodotto)
        {
            Console.WriteLine("Sto facendo la add");
            _context.ProdottiTerminati.Add(prodotto);
            _context.SaveChanges();
        }

        public void Update(ProdottoTerminato prodotto)
        {
            Console.WriteLine("Sto facendo la update");
            _context.ProdottiTerminati.Update(prodotto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Console.WriteLine("Sto facendo la delete");

            var prodotto = _context.ProdottiTerminati.Find(id);
            if (prodotto != null)
            {
                _context.ProdottiTerminati.Remove(prodotto);
                _context.SaveChanges();
            }
        }
    }
}
