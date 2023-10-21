<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-4">
        HOME BUTTON CREATE DROPDOWN ABOUT
      </div>
      <div class="col-4 text-center">
        LOGO
      </div>
      <div class="col-4 text-end">
        <Login/>
      </div>
    </section>
  </div>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style lang="scss" scoped>

</style>
