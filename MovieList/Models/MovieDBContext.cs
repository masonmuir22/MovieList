//DBContext. Which has to do with a database persisting
//represents a combination of the Unit Of Work and Repository patterns such that
//it can be used to query from a database and group together changes that will then be written back to the store as a unit
using System;

using Microsoft.EntityFrameworkCore;

namespace MovieList.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}