<template>
  <div class="container-fluid">
    <section class="row bottom-border mb-2 justify-content-between justify-content-md-start">
      <div class="col-3 col-md-4 d-flex">
        <div v-if="user.isAuthenticated" class="dropdown">
          <button class="btn btn-secondary dropdown-toggle nav-text my-2 py-0" type="button" title="open the create dropdown" data-bs-toggle="dropdown" aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu nav-text">
            <li data-bs-toggle="modal" data-bs-target="#create-keep"><button class="dropdown-item selectable" type="button" title="Open a form to create a keep"><i class="mdi mdi-plus"></i> Keep</button></li>
            <li data-bs-toggle="modal" data-bs-target="#create-vault"><button class="dropdown-item selectable" type="button" title="Open a form to create a vault"><i class="mdi mdi-plus"></i> Vault</button></li>
          </ul>
        </div>
      </div>
      <div class="col-3 col-md-4 text-center">
        <router-link :to="{name: 'Home'}" title="Go to the Home page">
          <button class="btn btn-secondary nav-text w-50 my-2 py-0"><i class="mdi mdi-home"></i> Keepr </button>
        </router-link>
      </div>
      <div class="col-3 col-md-4 text-center">
        <section class="row justify-content-end">
          <div class="col-12 col-md-3">
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
.nav-text{
  font-size: 1.5rem;
  font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
  font-weight: bold;
}
</style>
