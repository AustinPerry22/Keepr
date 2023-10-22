<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
    <ModalWrapper id="active-keep">
        <template #body>
          <KeepDetails/>
        </template>
    </ModalWrapper>
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import KeepDetails from './components/KeepDetails.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
