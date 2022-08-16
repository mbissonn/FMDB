<template>

  <div id="app">

    <body>

      <h1>Movie Database</h1>

      <div style="display: flex; justify-content: flex-end">
        <b-button
          v-b-modal.modal-1
         
          class="btn"
          variant="primary"
          style="padding: 7.5px"
        >
          <b-icon icon="plus-circle-fill"></b-icon> Add
        </b-button>
        <b-modal 
          id="modal-1" 
          title = "Modification Form"
          header-bg-variant="secondary"
          header-border-variant="light"
          body-text-variant="dark"
          footer-border-variant="light"
          footer-bg-variant="warning"
        >
          <b-row class = "mr-1">
          </b-row>  
          <p class ="my-4">Hello from modal!</p>
        </b-modal>
      </div>

      <div>
        <List />
      </div>

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
