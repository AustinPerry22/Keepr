<template>
  <div class="container-fluid">
    <section class="row bottom-border mb-3">
      <div class="col-4 d-flex">
        <router-link :to="{name: 'Home'}">
          <button class="btn btn-info">Home</button>
        </router-link>
        <div v-if="user.isAuthenticated" class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu">
            <li data-bs-toggle="modal" data-bs-target="#create-keep"><a class="dropdown-item selectable">New Keep</a></li>
            <li data-bs-toggle="modal" data-bs-target="#create-vault"><a class="dropdown-item selectable">New Vault</a></li>
          </ul>
        </div>
      </div>
      <div class="col-4 text-center">
        <img src="../assets/img/logo.png" alt="" class="logo">
      </div>
      <div class="col-4 text-end">
        <Login/>
      </div>
    </section>
  </div>
</template>

<script>
import { computed } from 'vue';
import Login from './Login.vue';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      user: computed(()=> AppState.user)
    }
  },
  components: { Login }
}
</script>

<style lang="scss" scoped>
.bottom-border{
  border-bottom: solid rgba(65, 60, 60, 0.788) .5dvh;
}
.logo{
  height: 6dvh;
}
</style>
