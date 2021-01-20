using Microsoft.EntityFrameworkCore;

namespace PROJEKAT.models
{
    public class prodavnicaContext : DbContext
    {
        public DbSet<prodavnica> Prodavnice { get; set; }
        public DbSet<proizvod> Proizvodi { get; set; }
        public DbSet<dobavljac> Dobavljaci { get; set; }

        public prodavnicaContext(DbContextOptions options) : base(options)
        {
        }
    }
}