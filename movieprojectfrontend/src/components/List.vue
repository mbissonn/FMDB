<template>
  <div>
    <div style="display: flex; justify-content: flex-end">
      <b-button
        @click="addCopyEditHandler(0)"
        class="btn"
        variant="primary"
        style="padding: 7.5px"
      >
        <b-icon icon="plus-circle-fill"></b-icon> Add
      </b-button>

      <b-modal
        id="modal-1"
        title="Movie Record Tool"
        header-bg-variant="dark"
        header-border-variant="light"
        header-close-variant="light"
        body-text-variant="dark"
        footer-border-variant="light"
        footer-bg-variant="secondary"
        v-model="modalShow"
      >
        <form ref="form" @submit.stop.prevent="submitForm">
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
        <template slot="modal-footer">
          <b-button @click="saveHandler()" variant="primary">Save</b-button>
          <b-button @click="cancelHandler()" variant="warning">Cancel</b-button>
          <b-button @click="deleteItem(id)" variant="danger">Delete</b-button
          >
        </template>
      </b-modal>
    </div>

    <b-table striped dark hover outlined :items="items" :fields="fields">
      <template v-slot:cell(actions)="{ item }">
        <div style="width: 230px">
          <button class="btn">
            <b-icon
              icon="pencil-square"
              @click="addCopyEditHandler('edit',item)"
              variant="white"
            ></b-icon>
          </button>
          <button class="btn">
            <b-icon
              icon="files"
              @click="addCopyEditHandler('copy',item)"
              variant="white"
            ></b-icon>
          </button>
          <button class="btn">
            <b-icon
              icon="trash"
              @click="deleteItem(item.id)"
              variant="danger"
            ></b-icon>
          </button>
        </div>
      </template>
    </b-table>
  </div>
</template>

<script>
import MovieService from "../services/MovieService";

export default {
  data() {
    return {
      modalShow: false,

      buttonOrigin: "",

      id: null,
      name: "",
      releaseYear: null,
      description: "",
      nameState: null,
      releaseYearState: null,
      descriptionState: null,

      fields: ["name", "releaseYear", "description", "Actions"],
      items: [],
    };
  },

  created() {
    MovieService.getAllMovies().then((response) => {
      this.items = response.data;
    });
  },

  methods: {

    cancelHandler() {
      this.modalShow = false;
    },

    addCopyEditHandler(buttonOrigin, item) {
      this.modalShow = true;
      this.buttonOrigin = buttonOrigin;
      this.id = null;
      if (item != null) {
        this.id = item.id;
        this.name = item.name;
        this.releaseYear = item.releaseYear;
        this.description = item.description;
      } else {
        this.id = null;
        this.name = "";
        this.releaseYear = null;
        this.description = "";
      }
    },

    saveHandler(){
        if(this.buttonOrigin=="copy"||this.buttonOrigin=="add"){
            this.addMovie();
        } else {
            const item = this.getMovie(this.id);
            this.editItem(item);
        }
    },

    getMovie(movieId){
        MovieService.getMovieById(movieId);
    },

    editItem(item) {
      MovieService.updateMovie(item.id, item)
      window.location.reload();
    },
    copyItem(item) {
      MovieService.addMovie(item);
      window.location.reload();
    },
    deleteItem(id) {
      MovieService.deleteMovie(id);
      window.location.reload();
    },
    addMovie() {
          const item = JSON.stringify({
          name: this.name,
          releaseYear: this.year,
          description: this.description,
          });
      MovieService.addMovie(item);
    },

    // checkFormValidity() {
    //   const valid = this.$refs.form.checkValidity();
    //   this.nameState = valid;
    //   this.releaseYearState = valid;
    //   this.descriptionState = valid;
    //   return valid;
    // },

    // handleOk(bvModalEvent) {
    //   bvModalEvent.preventDefault();
    //   this.submitForm();
    // },

    // submitForm() {
    //   if (!this.checkFormValidity()) {
    //     return;
    //   }
    //   this.addMovie;
    //   this.$nextTick(() => {
    //     this.$bvModal.hide("modal-prevent-closing");
    //   });
    //   this.resetModal;
    // },

    // resetModal() {
    //   this.name = "";
    //   this.nameState = null;
    //   this.releaseYear = "";
    //   this.releaseYearState = null;
    //   this.description = "";
    //   this.descriptionState = null;
    // },
  },
};
</script>

<style>
th {
  min-width: 150px;
}

tr {
  vertical-align: middle;
}

button {
  border: none;
  background: none;
  margin-bottom: 7.5px;
}
</style>  