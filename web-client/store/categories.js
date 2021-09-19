const initState = () => ({
  categories: []
})

export const state = initState;

export const mutations = {
  setCategories(state, {categories}) {
    state.categories = categories;
  },
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchCategories ({commit}) {
    const categories = await this.$axios.$get("/api/categories");
    commit("setCategories", {categories});
  }
}
