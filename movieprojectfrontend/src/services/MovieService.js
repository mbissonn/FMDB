import axios from 'axios';

export default {

    addMovie(movie) {
        return axios.post(`/api/movie`, movie)
    },

    getAllMovies() {
        return axios.get('https://localhost:44388/api/movie')
    },

    getMovieById(movieId) {
        return axios.get(`https://localhost:44388/api/movie/${movieId}`)
    },

    updateMovie(movieId, movie) {
        return axios.put(`https://localhost:44388/api/movie/${movieId}`, movie)
    },

    deleteMovie(movieId) {
        return axios.delete(`https://localhost:44388/api/movie/${movieId}`)
    }
}
