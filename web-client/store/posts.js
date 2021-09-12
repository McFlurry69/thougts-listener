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
    const posts = (await Axios.get("http://localhost:5000/api/posts")).data;
    commit("setPosts", {posts});
  },
  async createPosts ({commit, dispatch}, {post}) {
    await Axios.post("http://localhost:5000/api/posts", post);
    await dispatch("fetchPosts")
  }
}
