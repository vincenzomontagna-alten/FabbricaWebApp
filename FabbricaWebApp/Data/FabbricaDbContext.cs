using FabbricaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FabbricaWebApp.Data
{

        public class FabbricaDbContext : DbContext
        {
            public FabbricaDbContext(DbContextOptions<FabbricaDbContext> options) : base(options) { }

            public DbSet<ProdottoTerminato> ProdottiTerminati { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    // Mappatura della tabella "Prodotti"
                    modelBuilder.Entity<ProdottoTerminato>(entity =>
                    {
                        entity.ToTable("ProdottiTerminati"); // Nome esatto della tabella nel database

                        entity.HasKey(p => p.Id); // Chiave primaria

                        entity.Property(p => p.NomeProdotto)
                              .IsRequired()
                              .HasMaxLength(100); // Lunghezza massima come da definizione SQL

                        entity.Property(p => p.Quantita)
                              .IsRequired(); // Campo obbligatorio
                    });

                    base.OnModelCreating(modelBuilder);
                }
            }
}



