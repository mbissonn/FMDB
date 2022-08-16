<template>
  <div class="movies">
    <movie
      v-for="movie in movieList"
      v-bind:key="movie.movieId"
      v-bind:movie="movie"
    >
    </movie>
  </div>
</template>

<script>

import MovieService from "../services/MovieService";
import Movie from "./Movie.vue";

export default {
  name: "movie-list",
  components: {
    Movie,
  },

  data() {
    return {
      movie: {
        id: 0,
        name: "",
        description: "",
        releaseYear: 0,
      },
      movieList: [],
    };
  },

  methods: {},

  created() {
    MovieService.getAllMovies().then((response) => {
      this.movieList = response.data;
    });
  },
};
</script>

<style>
.card-content {
  /* background-color: #367588; */
  background-color: #ece1a2;
  /* background-color: #F89880; */
  /* background-color: #6ca360; */

  color: black;
  border: 10px solid white;
  font-family: "Cinzel", serif;
}

.notification {
  padding-right: 350px;
}

h1 {
  font-weight: bold;
}
</style>

