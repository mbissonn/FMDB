<template>
  <div id="app">
    <div>
      <h2>Movie Database</h2>
      <div style="display: flex; justify-content: flex-end">
        <button class="btn btn-primary" @click="addMovie()" style="padding: 7.5px">
          <b-icon icon="plus-circle-fill"></b-icon> Add
        </button>
      </div>
      <div><List /></div>
    </div>
  </div>
</template>

<script>
import List from "./components/List.vue";

export default {
  name: "App",
  components: {
    List,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
h2 {
  text-align: center;
}
</style>
