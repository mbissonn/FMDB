using Microsoft.AspNetCore.Mvc;
using MovieProject.DAO;
using MovieProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovie movieDAO { get; }
        public MovieController(IMovie movieDAO)
        {
            this.movieDAO = movieDAO;
        }

        // POST api/<MovieController>
        [HttpPost]
        public Movie Post([FromBody] Movie movie)
        {
            return movieDAO.addMovie(movie);
        }

        // GET api/<MovieController>

        [HttpGet]
        public List<Movie> getAllMovies()
        {
            return movieDAO.getAllMovies();
        }

        // GET api/<MovieController>/{movieId}
        [HttpGet("{movieId}")]
        public Movie Get(int movieId)
        {
            return movieDAO.getMovieById(movieId);
        }

        // PUT api/<MovieController>/{movieId}
        [HttpPut("{movieId}")]
        public Movie Put(int id, [FromBody] Movie movie)
        {
            return movieDAO.updateMovie(movie);
        }

        // DELETE api/<MovieController>/{movieId}
        [HttpDelete("{movieId}")]
        public void Delete(int movieId)
        {
            movieDAO.deleteMovie(movieId);
        }
    }
}
