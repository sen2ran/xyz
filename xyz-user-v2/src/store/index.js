import { createStore } from "vuex";

export default createStore({
  state: {
    user: {
      email: null,
      name: null,
      isApproved: null
    },
    addToCart: []
  },
  mutations: {
    setUser(state, payload) {
      state.user = payload;
    }
  },
  actions: {
    setUser({ commit }, payload) {
      commit("setUser", payload);
    }
  },
  getters: {
    getUser: state => state.user
  }
});
