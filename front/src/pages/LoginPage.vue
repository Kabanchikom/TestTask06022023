<template>
  <div v-if="loginStatus !== loginStatus.loggedIn">
    <form @submit.prevent="handleLogin">
      <div class="form-group">
        <label for="">Username:</label>
        <input ref="username" v-model="username" type="text" class="form-control" placeholder="Enter username">
        <div class="invalid-feedback" v-if="errors[0]">
          {{ errors[0].message }}
        </div>
      </div>

      <div class="form-group">
        <label for="">Password:</label>
        <input ref="password" v-model="password" type="password" class="form-control"
               placeholder="Enter password">
        <div class="invalid-feedback" v-if="errors[1]">
          {{ errors[1].message }}
        </div>
      </div>

      <div class="form-group">
        <small class="form-text"
               :class="{ 'text-danger': loginErrorMessage, 'text-success': loginSuccessMessage}">
          <div v-if="loginSuccessMessage">
            {{ loginSuccessMessage ?? '&nbsp;' }}
          </div>
          <div v-else>
            {{ loginErrorMessage ?? '&nbsp;' }}
          </div>
        </small>
      </div>

      <div class="form-group d-flex justify-content-between">
        <button type="submit" class="btn btn-primary">Login</button>
        <div v-if="showSpinner" class="spinner-border" role="status"></div>
      </div>
    </form>
  </div>
</template>

<script>
import {mapState} from "vuex"
import {loginStatus} from "@/store/accountModule";

export default {
  name: "LoginPage",

  data() {
    return {
      username: '',
      password: '',
      errors: []
    }
  },

  computed: {
    ...mapState({
      loginStatus: state => state.account.loginStatus,
      loginSuccessMessage: state => state.account.successMessage,
      loginErrorMessage: state => state.account.errorMessage
    }),
    showSpinner() {
      return this.loginStatus === loginStatus.logging;
    }
  },

  watch: {
    username() {
      // this.validate();
    },
    password() {
      // this.validate();
    }
  },

  methods: {
    async handleLogin() {
      if (this.loginStatus === loginStatus.logging || this.loginStatus === loginStatus.loggedIn) return;

      this.validate();

      if (this.errors.length === 0) {
        await this.$store.dispatch("account/login", {
          username: this.username,
          password: this.password
        })
      }
    },
    validate() {
      const username = this.$refs.username;
      const password = this.$refs.password;

      this.errors = [];
      username.classList.remove('is-invalid')
      password.classList.remove('is-invalid')

      if (!this.username) {
        username.classList.add('is-invalid');
        this.errors[0] = {
          message: 'Please provide a valid username'
        };
      }

      if (!this.password) {
        password.classList.add('is-invalid');
        this.errors[1] = {
          message: 'Please provide a valid password'
        };
      }
    }
  }
}
</script>

<style>
</style>
