import apiClient from "@/api/apiClient";
import router from "@/router/router";

export const loginStatus = {
    loggedOut: 'loggedOut',
    logging: 'logging',
    loggedIn: 'loggedIn',
    failure: 'failure'
};

export const accountModule = {
    state: () => ({
        loginStatus: loginStatus.loggedOut,
        errorMessage: null,
        successMessage: null,
        user: null,
    }),

    mutations: {
        loginSuccess(state, {user, message}) {
            state.loginStatus = loginStatus.loggedIn;
            state.user = user;
            state.successMessage = message;
            state.errorMessage = null;
        },
        logging(state) {
            state.loginStatus = loginStatus.logging;
            state.user = null;
            state.errorMessage = null;
            state.successMessage = null;
        },
        loginFailure(state, message) {
            state.loginStatus = loginStatus.failure;
            state.errorMessage = message;
            state.user = null;
            state.successMessage = null;
        },
        logout(state) {
            state.loginStatus = loginStatus.loggedOut;
            state.user = null;
            state.errorMessage = null;
            state.successMessage = null;
        },
    },

    actions: {
        async login({commit}, {username, password}) {
            commit('logging');
            try {
                const user = await apiClient.login(username, password);
                commit('loginSuccess', { 'user': user, 'message': 'You are successfully logged in' });
                await new Promise(resolve => setTimeout(resolve, 200));
                await router.push({name: 'profile'});
            } catch (e) {
                let message = 'Error: Status code ' + e;
                if (typeof(e) !== "number") message = e;
                if (e === 401) message = 'Wrong username or password';
                if (e === 500 || e === 422) message = 'Server side error';
                commit('loginFailure', message);
            }
        },
        async logout({commit}) {
            commit('logout');
            await router.push({name: 'login'});
        }
    },

    namespaced: true
}
