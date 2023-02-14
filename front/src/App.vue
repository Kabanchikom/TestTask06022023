<template>
  <div class="app">
      <nav-bar></nav-bar>
    <div class="mx-auto col-sm-4">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import {mapState} from "vuex"
import NavBar from '@/components/Navbar'

export default {
  components: {
    NavBar
  },
  computed: {
    ...mapState({
      loginStatus: state => state.account.loginStatus
    })
  }
}
</script>

<style>
* {
  padding: 0;
  box-sizing: border-box;
}

.app {
  padding: 20px;
}
</style>
