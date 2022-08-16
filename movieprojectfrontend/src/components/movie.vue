<template>
  <div>
    <div class="movie" v-bind:key="movie.movieId">
      <div class="card">
        <div class="card-content"></div>
        <div class="content">
          {{ movie.description }}
        </div>
        <button class="button is-danger is-outlined">Favorite</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "movie",
  props: ["movie"],

  methods: {},
};
</script>

<style>
.container {
  cursor: pointer;
}

.card-content:hover {
  background-color: limegreen;
}

img {
  border: solid black 1px;
}
</style>  