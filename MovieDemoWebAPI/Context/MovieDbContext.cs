using Microsoft.EntityFrameworkCore;
using MovieDemoWebAPI.Model;

namespace MovieDemoWebAPI.Context
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Producer> Producers { get; set; }



    }
}
