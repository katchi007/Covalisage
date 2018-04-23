using Microsoft.EntityFrameworkCore;

namespace covalisage.Domain
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options){}
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Annonce> Annonces { get; set; }


        
    }
}