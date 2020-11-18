export default {
  namespaced: true,
  state: {
    isAdvance: true,
  },
  mutations: {
    Set_User(state, payload) {
      state.user = payload;
    },
  },
  actions: {
    setUser({ commit }, payload) {
      commit("Set_User", payload);
    },
  },
  getters: {
    getUser: (state) => state.user,
  },
};
