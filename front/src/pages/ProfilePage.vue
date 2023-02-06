<template>
  <div v-if="user">
    <div class="container mt-5">
      <div class="row d-flex justify-content-center">
        <div class="col-3">
          <div class="avatar">
            <img src="/img/default-avatar.png">
          </div>
          <div class="d-flex justify-content-center">
            <button class="btn btn-danger" type="button" @click="handleLogout">Logout</button>
          </div>
        </div>
        <div class="col-6">
          <form>
            <div class="form-group">
              <label>Address</label>
              <input type="text" class="form-control" v-model="user.Address" disabled>
            </div>
            <div class="form-group">
              <label>City</label>
              <input type="text" class="form-control" v-model="user.City" disabled>
            </div>
            <div class="form-group">
              <label>Company</label>
              <input type="text" class="form-control" v-model="user.Company" disabled>
            </div>
            <div class="form-group">
              <label>Country</label>
              <input type="text" class="form-control" v-model="user.Country" disabled>
            </div>
            <div class="form-group">
              <label>CountryID</label>
              <input type="text" class="form-control" v-model="user.CountryId" disabled>
            </div>
            <div class="form-group">
              <label>Email</label>
              <input type="email" class="form-control" v-model="user.Email" disabled>
            </div>
            <div class="form-group">
              <label>Email confirm</label>
              <input type="email" class="form-control" v-model="user.EmailConfirm" disabled>
            </div>
            <div class="form-group">
              <label>EntityId</label>
              <input type="text" class="form-control" v-model="user.EntityId" disabled>
            </div>
            <div class="form-group">
              <label>FTP Host</label>
              <input type="text" class="form-control" v-model="user.FTPHost" disabled>
            </div>
            <div class="form-group">
              <label>FTP Port</label>
              <input type="text" class="form-control" v-model="user.FTPPort" disabled>
            </div>
            <div class="form-group">
              <label>First Name</label>
              <input type="text" class="form-control" v-model="user.FirstName" disabled>
            </div>
            <div class="form-group">
              <label>Last Name</label>
              <input type="text" class="form-control" v-model="user.LastName" disabled>
            </div>
            <div class="form-group">
              <label>Mobile</label>
              <input type="text" class="form-control" v-model="user.Mobile" disabled>
            </div>
            <div class="form-group">
              <label>Mobile Confirm</label>
              <input type="text" class="form-control" v-model="user.MobileConfirm" disabled>
            </div>
            <div class="form-group">
              <label>Phone</label>
              <input type="text" class="form-control" v-model="user.Phone" disabled>
            </div>
            <div class="form-group">
              <label>Status</label>
              <input type="text" class="form-control" v-model="user.Status" disabled>
            </div>
            <div class="form-group">
              <label>Zip</label>
              <input type="text" class="form-control" v-model="user.Zip" disabled>
            </div>
            <div class="form-group">
              <label>Lid</label>
              <input type="text" class="form-control" v-model="user.lid" disabled>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {mapState} from "vuex"

export default {
  name: "ProfilePage",

  computed: {
    ...mapState({
      user: state => state.account.user
    }),
  },

  methods: {
    handleLogout() {
      this.$store.dispatch("account/logout");
    }
  }
}
</script>

<style scoped>
.avatar img {
  max-width: 100%;
  margin-bottom: 10%;
}
</style>
