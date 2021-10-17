const initState = () => ({
  uploadPromise: null,
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
  createFileUploadTask ({commit, dispatch}, {form}) {
    const uploadPromise = this.$axios.$post("/api/files", form);
    commit("setTask", {uploadPromise})
  },

}
