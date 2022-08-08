using MovieProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.DAO
{
    public class MovieDAO : IMovie
    {
        //Because this instance variable has no "set;", it can only be set in the constructor.
        private string connectionString { get; }
        public MovieDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Movie addMovie(Movie movieToAdd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Movies OUTPUT INSERTED id VALUES(@title)");
                cmd.Parameters.AddWithValue("@title", movieToAdd.title);
                movieToAdd.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return movieToAdd;
        }

        public void deleteMovie(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Movies WHERE id = @movieId");
                cmd.Parameters.AddWithValue("@movieId", id);
                cmd.ExecuteNonQuery();
             }
        }

        public List<Movie> getAllMovies()
        {
            List<Movie> output = new List<Movie>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM movies";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    output.Add(createMovieFromReader(reader));
                }
            }
            return output;
        }

        public Movie getMovie(int id)
        {
            Movie output = new Movie();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM movies where id=@movieId";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@movieId", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    output = createMovieFromReader(reader);
                }
            }
            return output;
        }

        public void updateMovie(Movie movieToUpdate)
        {
            throw new NotImplementedException();
        }

        private Movie createMovieFromReader(SqlDataReader dataIn)
        {
            Movie output = new Movie();
            output.id = Convert.ToInt32(dataIn["id"]);
            output.title = Convert.ToString(dataIn["title"]);
            return output;
        }
    }
}
