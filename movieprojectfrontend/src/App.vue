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
          title = "Create a New Movie Record"
          header-bg-variant="dark"
          header-border-variant="light"
          body-text-variant="dark"
          footer-border-variant="light"
          footer-bg-variant="secondary"
        >
          <form ref="form" @submit.stop.prevent="handleSubmit">
            <b-form-group
              label="Name:"
              label-for="name-input"
              invalid-feedback="Name is required"
              :state="nameState"
            >
              <b-form-input
                id="name-input"
                v-model="name"
                :state="nameState"
                required
              ></b-form-input>
            </b-form-group>
            
            <b-form-group
              label="Release Year:"
              label-for="release-year-input"
              invalid-feedback="Release year is required"
              :state="releaseYearState"
            >
              <b-form-input
                id="release-year-input"
                v-model="releaseYear"
                :state="releaseYearState"
                required
              ></b-form-input>
            
            </b-form-group>
            <b-form-group
              label="Description:"
              label-for="description-input"
              invalid-feedback="Description is required"
              :state="descriptionState"
            >
              <b-form-input
                id="description-input"
                v-model="description"
                :state="descriptionState"
                required
              ></b-form-input>
            </b-form-group>
            
          </form>
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
  data() {
    return{
      name:'',
      releaseYear:null,
      description:'',
      nameState: null,
      releaseYearState: null,
      descriptionState: null
    }
  }
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
