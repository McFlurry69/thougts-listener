<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title class="headline">
          Hey there
          <div v-for="p in posts">
            <h2>{{p.article}}</h2>
            <h3>{{p.bodyText}}</h3>
            <img :src="`http://localhost:5000/api/images/${p.image}`" alt="">
          </div>
        </v-card-title>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Axios from 'axios'
import {mapState, mapMutations, mapActions} from 'vuex';

export default {
  computed: {
    ...mapState({
      message: state => state.message
    }),
    ...mapState("posts", {
      posts: state => state.posts
    })
  },
  async fetch(){
    const res = await this.$store.dispatch("posts/fetchPosts");
    console.log(res);
  }
}
</script>
