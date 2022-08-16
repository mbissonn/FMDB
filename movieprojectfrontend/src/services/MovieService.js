import axios from 'axios';

export default {

    addMovie(movie) {
        return axios.post(`/api/movie`, movie)
    },

    getAllMovies() {
        return axios.get('/api/movie')
    },

    getMovieById(movieId) {
        return axios.get(`/api/movie/${movieId}`)
    },

    updateMovie(movieId, movie) {
        return axios.put(`/api/movie/${movieId}`, movie)
    },

    deleteMovie(movieId) {
        return axios.delete(`/api/movie/${movieId}`)
    }
}
