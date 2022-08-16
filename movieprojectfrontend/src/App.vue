<template>
  <div id="app">
    <div>
      <h2>Movie Database</h2>
      <movie-list/>
    </div>
  </div>
</template>

<script>
import MovieList from './components/MovieList.vue'
export default {
  name: 'App',
  components: {
    MovieList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
