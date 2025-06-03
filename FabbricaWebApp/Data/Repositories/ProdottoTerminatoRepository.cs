using FabbricaWebApp.Models;

namespace FabbricaWebApp.Data.Repositories
{
    public class ProdottoTerminatoRepository
    {
        private readonly FabbricaDbContext _context;

        public ProdottoTerminatoRepository(FabbricaDbContext context)
        {
            _context = context; // Usa OnConfiguring per la connessione
        }

        public List<ProdottoTerminato> GetAll()
        {
            return _context.ProdottiTerminati.ToList();
        }

        public ProdottoTerminato? GetById(int id)
        {
            return _context.ProdottiTerminati.Find(id);
        }

        public void Aggiungi(ProdottoTerminato prodotto)
        {
            _context.ProdottiTerminati.Add(prodotto);
            _context.SaveChanges();
        }

        public void Aggiorna(ProdottoTerminato prodotto)
        {
            _context.ProdottiTerminati.Update(prodotto);
            _context.SaveChanges();
        }

        public void Elimina(int id)
        {
            var prodotto = _context.ProdottiTerminati.Find(id);
            if (prodotto != null)
            {
                _context.ProdottiTerminati.Remove(prodotto);
                _context.SaveChanges();
            }
        }
    }
}
