const initState = () => ({
  uploadPromise: null,
  type: ""
})

export const state = initState;

export const mutations = {
  setTask(state, {uploadPromise}) {
    state.uploadPromise = uploadPromise;
  },
  setType(state, {type}){
    state.type = type
  },
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  createImageTask ({commit, dispatch}, {form}) {
    const uploadPromise = this.$axios.$post("/api/images", form);
    commit("setTask", {uploadPromise})
  }
}
