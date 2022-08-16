<template>
  <div>
    <b-table striped hover outlined :items="items" :fields="fields"
      ><template v-slot:cell(actions)="{ item }">
            <button class="btn"><b-icon icon="pencil-square" @click="editItem(item)"></b-icon></button>
            <button class="btn"><b-icon icon="files" @click="copyItem(item)"></b-icon></button>
            <button class="btn"><b-icon icon="trash" @click="deleteItem(item)" variant="danger"></b-icon> </button>
        </template
    ></b-table>
  </div>
</template>

<script>
import MovieService from "../services/MovieService";
export default {
  data() {
    return {
      fields: ["name", "releaseYear", "description", "Actions"],
      items: [],
    };
  },
  created() {
    MovieService.getAllMovies().then((response) => {
      this.items = response.data;
    });
  },
};
</script>

<style>
tr {
vertical-align: middle;
};

button {
    border: none;
    background: none;
    margin-bottom: 7.5px;
}
</style>  