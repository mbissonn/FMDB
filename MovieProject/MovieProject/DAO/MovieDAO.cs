using MovieProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Model.Exceptions;

namespace MovieProject.DAO
{
    public class MovieDAO : IMovie
    {
        private string connectionString { get; }

        public MovieDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // CREATE Method

        public Movie addMovie(Movie movieToAdd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Movies OUTPUT INSERTED id VALUES(@title, @description, @releaseYear)");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@title", movieToAdd.name);
                cmd.Parameters.AddWithValue("@description", movieToAdd.description);
                cmd.Parameters.AddWithValue("@releaseYear", movieToAdd.releaseYear);
                movieToAdd.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            try
            {
                return getMovieById(movieToAdd.id);
            } catch (Exception)
            {
                throw new MovieException("Could not retrieve created movie.");
            }
        }

        //  RETRIEVE Methods

        public List<Movie> getAllMovies()
        {
            List<Movie> allMovies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies");
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allMovies.Add(createMovieFromReader(reader));
                }
            }
            if (allMovies.Count == 0)
            {
                throw new MovieException("Could not retrieve any movies.");
            }
            return allMovies;
        }

        public Movie getMovieById(int id)
        {
            Movie movie = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM movies where id = @movieId");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@movieId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    movie = createMovieFromReader(reader);
                }
            }
            if (movie == null)
            {
                throw new MovieException("Could not retrieve movie.");
            }
            return movie;
        }

        // Update Method

        public Movie updateMovie(Movie movieToUpdate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE movies SET name = @name, description = @description, release_year = @releaseYear WHERE id = @movieId");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@name", movieToUpdate.name);
                cmd.Parameters.AddWithValue("@description", movieToUpdate.description);
                cmd.Parameters.AddWithValue("@releaseYear", movieToUpdate.releaseYear);
                cmd.Parameters.AddWithValue("@releaseYear", movieToUpdate.id);
                cmd.ExecuteNonQuery();
                movieToUpdate = getMovieById(movieToUpdate.id);
            }
            if (movieToUpdate == null)
            {
                throw new MovieException("Could not update movie.");
            }
            return movieToUpdate;
        }


        // DELETE Method

        public void deleteMovie(int movieId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Movies WHERE id = @movieId");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.ExecuteNonQuery();
                try
                {
                    getMovieById(movieId);
                } catch (MovieException)
                {
                    return;
                }
                throw new MovieException("Could not delete movie.");
            }
        }


        private Movie createMovieFromReader(SqlDataReader dataIn)
        {
            Movie movie = new Movie();
            movie.id = Convert.ToInt32(dataIn["id"]);
            movie.name = Convert.ToString(dataIn["name"]);
            movie.description = Convert.ToString(dataIn["description"]);
            movie.releaseYear = Convert.ToInt32(dataIn["release_year"]);
            return movie;
        }
    }
}
