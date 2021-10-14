import Axios from "axios";

const initState = () => ({
  posts: []
})

export const state = initState;

export const mutations = {
  setPosts(state, {posts}) {
    state.posts = posts;
  },
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchPosts ({commit}) {
    const posts = await this.$axios.$get("/api/posts");
    console.log(posts);
    commit("setPosts", {posts});
  },
  async createPost ({commit, dispatch}, {post}) {
    await this.$axios.$post("/api/posts", post);
    await dispatch("fetchPosts")
  }
}
