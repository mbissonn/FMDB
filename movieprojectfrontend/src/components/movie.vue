<template>
  <div>
    <b-table striped hover :items="items" :fields="fields"></b-table>
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

</style>  