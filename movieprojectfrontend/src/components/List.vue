<template>

  <div>
    <b-table striped dark hover outlined :items="items" :fields="fields">
      <template v-slot:cell(actions)="{ item }">
          <div style="width:230px">
            <button class="btn"><b-icon icon="pencil-square" @click="editItem(item)" variant="white"></b-icon></button>
            <button class="btn"><b-icon icon="files" @click="copyItem(item)" variant="white"></b-icon></button>
            <button class="btn"><b-icon icon="trash" @click="deleteItem(item)" variant="danger"></b-icon> </button>
       </div>
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
    methods: {
        editItem(){
            window.location.reload();
        },
        copyItem(item){
            MovieService.addMovie(item);
            window.location.reload();
        },
        deleteItem(item){
            MovieService.deleteMovie(item.id);
            window.location.reload();
        }
    }
};

</script>

<style>

th {
    min-width: 150px;
}

tr {
    vertical-align: middle;
};

button {
    border: none;
    background: none;
    margin-bottom: 7.5px;
}

</style>  