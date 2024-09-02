import { createStore } from 'vuex';

export default createStore({
  state: {
    user: null,
    tickets: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    setTickets(state, tickets) {
      state.tickets = tickets;
    },
  },
  actions: {
    fetchUser({ commit }) {
      // 模拟API调用
      const user = { name: 'John Doe' };
      commit('setUser', user);
    },
    fetchTickets({ commit }) {
      // 模拟API调用
      const tickets = [{ id: 1, destination: 'Beijing' }, { id: 2, destination: 'Shanghai' }];
      commit('setTickets', tickets);
    },
  },
  modules: {},
});
