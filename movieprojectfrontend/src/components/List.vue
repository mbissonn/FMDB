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
        <form ref="form" validate_on_mount>
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
              v-validate="{ required: true, min_value: 1893, digits: 4 }"
              :state="validateState('release-year-input')"
            ></b-form-input>
          </b-form-group>

          <b-form-group
            label="Description:"
            label-for="description-input"
            invalid-feedback="Please limit your description to 500 characters."
            :state="descriptionState"
          >
            <b-form-textarea
              id="description-input"
              name="description-input"
              type="text"
              v-model="description"
              v-validate="{ required: false, max: 500 }"
              :state="validateState('description-input')"
              style="height: 500px"
            ></b-form-textarea>
          </b-form-group>
        </form>
        <template slot="modal-footer">
          <b-button @click="saveHandler(id)" variant="primary">Save</b-button>
          <b-button @click="cancelHandler()" variant="warning">Cancel</b-button>
          <b-button
            v-show="buttonOrigin == 'edit'"
            @click="showDeleteModal('', id)"
            variant="danger"
            >Delete</b-button
          >
        </template>
      </b-modal>
      <b-modal
        id="delete-modal"
        title="Delete Record"
        header-bg-variant="warning"
        header-text-variant="dark"
        header-border-variant="danger"
        header-close-variant="primary"
        body-text-variant="danger"
        body-bg-variant="light"
        footer-border-variant="danger"
        footer-bg-variant="warning"
        okay-variant="danger"
        v-model="deleteShow"
        @ok="deleteItem(id)"
      >
        <p style="text-align: center; font-size: larger; padding: 10px 0 10px">
          Are you sure that you want to delete this record?
        </p>
      </b-modal>

      <b-modal
        id="confirmation-modal"
        title="Success!"
        header-text-variant="light"
        header-bg-variant="secondary"
        body-text-variant="success"
        v-model="confirmationShow"
        hide-footer
      >
        <p style="text-align: center; font-size: larger; padding: 10px 0 10px">
          {{ message }}
        </p>
      </b-modal>
    </div>

    <b-table
      striped
      dark
      hover
      outlined
      :items="items"
      :fields="fields"
      :sort-by.sync="sortBy"
      :sort-desc.sync="sortDesc"
      sort-icon-left
      responsive="sm"
    >
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
              @click="showDeleteModal('yes', item.id)"
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
      deleteShow: false,
      confirmationShow: false,
      message: "",

      buttonOrigin: "",

      id: null,
      name: "",
      releaseYear: null,
      description: "",
      nameState: null,
      releaseYearState: null,
      descriptionState: null,

      sortBy: "name",
      sortDesc: false,

      fields: [
        { key: "name", sortable: true },
        { key: "releaseYear", sortable: true },
        { key: "description", sortable: true },
        { key: "actions", sortable: false },
      ],
      items: [],
    };
  },

  created() {
    MovieService.getAllMovies().then((response) => {
      this.items = response.data;
    });
  },

  updated() {
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
        if (buttonOrigin == "edit") {
          this.id = item.id;
        }
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
      if (
        (this.validateState("name-input") &&
          this.validateState("release-year-input") &&
          (this.validateState("description-input") ||
            this.validateState("description-input") == null)) ||
        (this.validateState("name-input") == null &&
          this.validateState("release-year-input") == null &&
          (this.validateState("description-input") == null ||
            this.validateState("description-input")) &&
          this.buttonOrigin != "add")
      ) {
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
        this.buttonOrigin == null;
      } else {
        return;
      }
    },

    showDeleteModal(fromRow, id) {
      if (fromRow == "yes" || this.buttonOrigin == "edit") {
        this.id = id;
        this.deleteShow = true;
      } else {
        return;
      }
    },

    showConfirmationModal(message) {
      this.message = message;
      this.confirmationShow = true;
    },

    getMovie(movieId) {
      MovieService.getMovieById(movieId);
    },

    editItem(id, item) {
      MovieService.updateMovie(id, item).then(
        (this.modalShow = false),
        this.showConfirmationModal("Record successfully updated.")
      );
    },

    deleteItem(id) {
      MovieService.deleteMovie(id).then(
        (this.modalShow = false),
        this.showConfirmationModal("Record successfully deleted.")
      );
    },

    addMovie(item) {
      MovieService.addMovie(item).then(
        (this.modalShow = false),
        this.showConfirmationModal("Record successfully added.")
      );
    },
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