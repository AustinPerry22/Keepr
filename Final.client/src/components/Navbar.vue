<template>
  <div class="container-fluid">
    <section class="row bottom-border mb-2 justify-content-between justify-content-md-start">
      <div class="col-3 col-md-4 d-flex">
        <div v-if="user.isAuthenticated" class="dropdown mt-2">
          <button class="btn btn-secondary dropdown-toggle" type="button" title="open the create dropdown" data-bs-toggle="dropdown" aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu">
            <li data-bs-toggle="modal" data-bs-target="#create-keep"><button class="dropdown-item selectable" type="button" title="Open a form to create a keep">New Keep</button></li>
            <li data-bs-toggle="modal" data-bs-target="#create-vault"><button class="dropdown-item selectable" type="button" title="Open a form to create a vault">New Vault</button></li>
          </ul>
        </div>
      </div>
      <div class="col-3 col-md-4 text-center">
        <router-link :to="{name: 'Home'}" title="Go to the Home page">
          <img src="../assets/img/logo.png" alt="" class="logo">
        </router-link>
      </div>
      <div class="col-3 col-md-4 text-center">
        <section class="row justify-content-end">
          <div class="col-9 col-md-3 mt-2">
            <Login/>
          </div>
        </section>
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
@media screen and (max-width: 768px){
 .logo{
  height: 9.5dvh;
 }
}
</style>
