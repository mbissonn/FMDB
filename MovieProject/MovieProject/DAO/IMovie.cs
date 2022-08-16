using MovieProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.DAO
{
    public interface IMovie
    {
        List<Movie> getAllMovies();
        Movie getMovieById(int id);
        Movie addMovie(Movie movieToAdd);
        Movie updateMovie(Movie movieToUpdate, int movieId);
        void deleteMovie(int id);
    }
}
