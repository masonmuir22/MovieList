//EF repository which makes it so you can iterate through it

using System;
using System.Linq;

namespace MovieList.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDBContext _context;

        //Constructor
        public EFMovieRepository(MovieDBContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
