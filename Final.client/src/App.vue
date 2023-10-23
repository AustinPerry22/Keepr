<template>
  <header class="sticky-top">
    <Navbar class="bg-light"/>
  </header>
  <main>
    <router-view />
    <ModalWrapper id="active-keep">
        <template #body>
          <KeepDetails/>
        </template>
    </ModalWrapper>
    <ModalWrapper id="create-keep">
      <template #body>
        <KeepForm/>
      </template>
  </ModalWrapper>
  <ModalWrapper id="create-vault">
      <template #body>
        <VaultForm/>
      </template>
  </ModalWrapper>
  <ModalWrapper id="edit-account">
      <template #body>
        <AccountForm/>
      </template>
  </ModalWrapper>
  </main>
</template>

<script>
import { computed, watchEffect } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import KeepDetails from './components/KeepDetails.vue'
import KeepForm from './components/KeepForm.vue'
import AccountForm from './components/AccountForm.vue'
import VaultForm from './components/VaultForm.vue'
import Pop from './utils/Pop'
import { vaultsService } from './services/VaultsService'

export default {
  setup() {
    watchEffect(()=>
    {
      AppState.account
      getMyVaults()
    })
    async function getMyVaults(){
      try {
        if(AppState.account.id)
        {
          vaultsService.getMyVaults()
        }
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepDetails, KeepForm, AccountForm, VaultForm }
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
