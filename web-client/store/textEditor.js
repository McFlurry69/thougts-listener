const initState = () => ({
  textContent: ''
})

export const state = initState;

export const mutations = {
  setTextContent(state, {content}) {
    console.log(content);
    state.textContent = content;
  },
  reset(state){
    Object.assign(state, initState())
  }
}


export const getters = {
  getTextContent(state){
    return state.textContent;
  }
}
