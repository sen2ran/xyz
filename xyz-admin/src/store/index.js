import Vue from "vue";
import Vuex from "vuex";
import modules from "./modules";

Vue.use(Vuex);

export default new Vuex.Store({
  modules,
  state: {},
  mutations: {
    SET_USER_TYPE(state, payload) {
      state.userType = payload;
    },
  },
  actions: {
    setUserType({ commit }, payload) {
      commit("SET_USER_TYPE", payload);
    },
  },
  getters: {
    getUserType: (state) => state.userType,
  },
});
