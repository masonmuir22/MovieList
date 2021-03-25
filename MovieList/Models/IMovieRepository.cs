//IMovieRepository which is a way to implement data access by encapsulating the
//set of objects persisted in a data store and the operations performed over them,
//providing a more object-oriented view of the persistence layer

using System;
using System.Linq;

namespace MovieList.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
    }
}
