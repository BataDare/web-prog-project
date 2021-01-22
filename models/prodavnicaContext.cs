using Microsoft.EntityFrameworkCore;

namespace PROJEKAT.models
{
    public class prodavnicaContext : DbContext
    {
        public DbSet<Prodavnica> Prodavnice { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }

        public prodavnicaContext(DbContextOptions options) : base(options)
        {
        }
    }
}