<template>
  <div id="app">
    <div>
      <h2 class = "title">Movie Database</h2>
      <div><List/></div>
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
  margin-top: 60px;
}
.title {
  text-align: center;
}
</style>
