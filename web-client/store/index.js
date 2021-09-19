import Axios from "axios";

const initState = () => ({
   message: "init"
})

export const state = initState;

export const mutations = {
  setMutation(state, message) {
    state.message = message;
  },
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchMessage ({commit, dispatch}) {
    const message = await this.$axios.$get("http://localhost:5000/api/home");
    commit("setMutation", message);
    await dispatch("posts/fetchPosts");
  }
}
