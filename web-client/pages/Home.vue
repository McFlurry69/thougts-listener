<template>
  <div>
    <Articles>
      <Banner />
    </Articles>
<!--
    <About />

    <Subscribe />

    <Social />-->

  </div>
</template>

<script>
import Articles from "@/components/home/Articles";
import Banner from "@/components/home/Banner";
import About from "@/components/home/About";
import Social from "@/components/home/Social";
import Subscribe from "@/components/home/Subscribe"
import {mapActions, mapState, mapMutations} from 'vuex'

  export default {
    computed: {
      ...mapState("posts", {
        posts: state => state.posts
      })
    },
    async fetch(){
      const res = await this.$store.dispatch("posts/fetchPosts");
    },
    components: {
      Articles,
      Banner,
      About,
      Subscribe,
      Social
    }
  }
</script>
