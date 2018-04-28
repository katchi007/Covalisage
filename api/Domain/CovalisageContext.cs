using api.Domain;
using Microsoft.EntityFrameworkCore;
namespace api.Domain
{
    public class CovalisageContext : DbContext
    {
        public CovalisageContext(DbContextOptions<CovalisageContext> options) : base(options){}
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
    }
}