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
        Movie getMovie(int id);
        Movie addMovie(Movie movieToAdd);
        void updateMovie(Movie movieToUpdate);
        void deleteMovie(int id);


    }
}
