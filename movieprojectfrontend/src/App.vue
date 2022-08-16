<template>

  <div id="app">
    <body>
      <h1>Movie Database</h1>
      <div style="display: flex; justify-content: flex-end">
        <button
          class="btn btn-primary"
          @click="addMovie()"
          style="padding: 7.5px"
        >
          <b-icon icon="plus-circle-fill"></b-icon> Add
        </button>
      </div>
      <div><List /></div>
    </body>
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
}

body {
  background: rgb(50, 50, 58);
  color: #ffffff;
}

h1 {
  font-weight: bold;
  margin-top: 25px;
  margin-bottom: -25px;
  margin-left: 30px;
}

button {
  margin-bottom: 7.5px;
  margin-right: 7.5px;
}

</style>
