<template>
  <v-form>
    <v-container>
      <v-row>
        <v-text-field v-model="form.articleTitle" label="Article title" required></v-text-field>
      </v-row>
      <v-row>
        <v-text-field v-model="form.articleSubTitle" label="Article subtitle" required></v-text-field>
      </v-row>
      <v-row>
        <v-select v-model="form.categories" :items="form.categories" label="Select" multiple chips deletable-chips
                  hint="What are the target regions" persistent-hint></v-select>
      </v-row>
      <v-row>
        <v-file-input accept="image/*" v-on:change="handleFile"></v-file-input>
      </v-row>
<!--      <v-row justify="center">
        <h1 v-bind="form.articleInput">{{form.articleInput}}</h1>
      </v-row>-->


      <div id="app" class="mt-15">
        <client-only>
          <TextEditor />
        </client-only>
      </div>

      <v-row class="flex justify-center py-6">
        <v-btn v-on:click="savePost">Create post</v-btn>
      </v-row>

    </v-container>
  </v-form>
</template>

<script>
import {mapMutations, mapActions, mapState, mapGetters} from "vuex";
import TextEditor from "@/components/Editor/TextEditor";


const initState = () => ({
  form: {
    articleTitle: '',
    articleSubTitle: '',
    categories: []
  }
})


export default {
  name: "Create",
  components:{
    TextEditor
  },
  data: initState,
  computed: {
    ...mapState("files", ["uploadPromise"]),
    ...mapState("categories", ["categories"]),
  },
  methods: {
    ...mapGetters("textEditor", ["getTextContent"]),
    async handleFile(file){
      if(!file) return;
      const form = new FormData();
      form.append("image", file);
      this.createFileUploadTask({form})
    },
    reset(){
      Object.assign(this.$data, initState());
    },
    async savePost(){
      if(!this.uploadPromise){
        return;
      }

      const image = await this.uploadPromise;
      await this.createPost({post: {title: this.form.articleTitle, subTitle: this.form.articleSubTitle, articleText: this.getTextContent(), headerImage: image, categories: this.form.categories}})
      this.resetImages();
      this.reset();
    },
    ...mapActions("files", ["createFileUploadTask"]),
    ...mapActions("posts", ["createPost"]),
    ...mapActions("categories", ["fetchCategories"]),
    ...mapMutations("files", {resetImages: 'reset'})
  },
  async fetch(){
    await this.$store.dispatch("categories/fetchCategories");
  }
}
</script>

<style scoped>

</style>
