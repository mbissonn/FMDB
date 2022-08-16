<template>
  <div>
    <div style="display: flex; justify-content: flex-end">
      <b-button
        @click="addCopyEditHandler('add')"
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
            invalid-feedback="Please enter a name up to 50 characters in length."
            :state="nameState"
          >
            <b-form-input
              id="name-input"
              name="name-input"
              type="text"
              v-model="name"
              v-validate="{ required: true, max: 50 }"
              :state="validateState('name-input')"
              required
            ></b-form-input>
          </b-form-group>

          <b-form-group
            label="Release Year:"
            label-for="release-year-input"
            invalid-feedback="Please enter a valid (4-digit) year no earlier than 1893."
            :state="releaseYearState"
          >
            <b-form-input
              id="release-year-input"
              name="release-year-input"
              type="number"
              v-model="releaseYear"
              v-validate="{ required: true, min_value:1893, digits: 4}"
              :state="validateState('release-year-input')"
            ></b-form-input>
          </b-form-group>

          <b-form-group
            label="Description:"
            label-for="description-input"
            invalid-feedback="Please enter a description up to 500 characters in length."
            :state="descriptionState"
          >
            <b-form-input
              id="description-input"
              name="description-input"
              type="text"
              v-model="description"
              v-validate="{ required: true, max: 500 }"
              :state="validateState('description-input')"
              required
            ></b-form-input>
          </b-form-group>
        </form>
        <template slot="modal-footer">
          <b-button @click="saveHandler(id)" variant="primary">Save</b-button>
          <b-button @click="cancelHandler()" variant="warning">Cancel</b-button>
          <b-button @click="deleteItem(id)" variant="danger">Delete</b-button>
        </template>
      </b-modal>
    </div>

    <b-table striped dark hover outlined :items="items" :fields="fields">
      <template v-slot:cell(actions)="{ item }">
        <div style="width: 230px">
          <button class="btn">
            <b-icon
              icon="pencil-square"
              @click="addCopyEditHandler('edit', item)"
              variant="white"
            ></b-icon>
          </button>
          <button class="btn">
            <b-icon
              icon="files"
              @click="addCopyEditHandler('copy', item)"
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
    validateState(ref) {
      if (
        this.veeFields[ref] &&
        (this.veeFields[ref].dirty || this.veeFields[ref].validated)
      ) {
        return !this.veeErrors.has(ref);
      }
      return null;
    },

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

    saveHandler(id) {
      const item = {
        name: this.name,
        releaseYear: parseInt(this.releaseYear),
        description: this.description,
      };
      console.log(item);
      if (this.buttonOrigin == "copy" || this.buttonOrigin == "add") {
        this.addMovie(item);
      } else {
        this.editItem(id, item);
      }
    },

    getMovie(movieId) {
      MovieService.getMovieById(movieId);
    },
    editItem(id, item) {
      MovieService.updateMovie(id, item);
      window.location.reload();
    },
    deleteItem(id) {
      MovieService.deleteMovie(id);
      window.location.reload();
    },
    addMovie(item) {
      MovieService.addMovie(item);
      window.location.reload();
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