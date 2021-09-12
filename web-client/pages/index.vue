<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <div>
          <v-file-input accept="image/*" v-on:change="handelFile"></v-file-input>
        </div>
        <v-card-text>
          There
          <p>{{message}}</p>
          <v-btn @click="resetMessage">Reset message</v-btn>
          <v-btn @click="resetPosts">Reset posts</v-btn>
        </v-card-text>
        <v-card-title class="headline">
          Hi2
        </v-card-title>
        <v-card-text v-if="posts">
            <p v-for="p in posts">
              {{p.article}} - {{p.bodyText}}
            </p>
        </v-card-text>
        <div>
          <v-text-field label="Article" v-model="post.article"></v-text-field>
          <v-text-field label="Text" v-model="post.bodytext"></v-text-field>
          <v-btn @click="savePost">Save post</v-btn>
        </div>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Axios from 'axios'
import {mapState, mapMutations, mapActions} from 'vuex';

export default {
  data: () => {
    return {
      post: {
        article: "",
        bodytext: ""
      }
    }
  },
  computed: {
    ...mapState({
      message: state => state.message
    }),
    ...mapState("posts", {
      posts: state => state.posts
    })
  },
  methods: {
    ...mapMutations({resetMessage: "reset"}),
    ...mapMutations("posts", {resetPosts: "reset"}),
    ...mapActions("posts", ["createPosts"]),
    async savePost(){
      await this.createPosts({post: {article: this.post.article, bodytext: this.post.bodytext}})
    },
    async handelFile(file){
      if(!file) return;
      const form = new FormData();
      form.append("image", file);
      const result = await Axios.post("http://localhost:5000/api/images", form);
      console.log("Result ", result);
    }
  },
  async fetch(){
    await this.$store.dispatch("posts/fetchPosts");
  }


  /*  data: () => ({
    message: ""
  }),
  asyncData(payload){
    return Axios.get("http://localhost:5000/api/home").then(({data}) => {
      return { message: data}
    })
  },*/

}
</script>
