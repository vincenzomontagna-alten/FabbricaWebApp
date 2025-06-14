﻿using FabbricaWebApp.Data.Repositories.RepositoriesInterfaces;
using FabbricaWebApp.Models;

namespace FabbricaWebApp.Data.Repositories
{
    public class ProdottoTerminatoRepository : IProdottoTerminatoRepositoryInterface
    {
        private readonly FabbricaDbContext _context;

        public ProdottoTerminatoRepository(FabbricaDbContext context)
        {
            _context = context; // Usa OnConfiguring per la connessione
        }

        public List<ProdottoTerminato> GetAll()
        {
            Console.WriteLine(_context.Database.ProviderName);
            return _context.ProdottiTerminati.ToList();
        }

        public ProdottoTerminato? GetById(int id)
        {
            return _context.ProdottiTerminati.Find(id);
        }

        public void Add(ProdottoTerminato prodotto)
        {
            _context.ProdottiTerminati.Add(prodotto);
            _context.SaveChanges();
        }

        public void Update(ProdottoTerminato prodotto)
        {
            _context.ProdottiTerminati.Update(prodotto);
            _context.SaveChanges();
        }

        public void Delete(int id)
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
