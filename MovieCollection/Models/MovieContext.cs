using Microsoft.EntityFrameworkCore;

namespace Mission06_Woodman.Models
{
    public class MovieContext : DbContext //Liaison 
    {
        public MovieContext(DbContextOptions<MovieContext> options ) : base (options)  //constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
