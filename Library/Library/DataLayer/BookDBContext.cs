using Microsoft.EntityFrameworkCore;
using Library.Entity;

namespace Library.DataLayer
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ThesisEntity> ThesisCollections { get; set; }


    }
}
