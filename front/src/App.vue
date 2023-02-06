<template>
  <div class="app">
    <router-view></router-view>
  </div>
</template>

<script>
import {mapState} from "vuex"

export default {
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
