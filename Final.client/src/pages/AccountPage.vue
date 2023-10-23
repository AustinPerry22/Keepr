<template>
  <div class="container-fluid">
      <section class="row justify-content-center position-relative">
          <div class="col-8 bg-cover text-center">
              <img :src="account.picture" alt="" class="profile-pic">
          </div>
      </section>
      <section class="row mt-5 pt-3">
          <div class="col-12 text-center">
              <h2><b>{{ account.name }}</b></h2>
              <h6>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</h6>
              <div>
                <button class="btn btn-info" data-bs-toggle="modal" data-bs-target="#edit-account">Edit Account</button>
              </div>
          </div>
      </section>
      <section class="row justify-content-center">
          <div class="col-10">
              <h3>Vaults</h3>
              <section class="row justify-content-center">
                  <div v-for="vault in vaults" :key="vault.id" class="col-2 g-3">
                      <VaultCard :vault="vault"/>
                  </div>
              </section>
          </div>
      </section>
      <section class="row justify-content-center mt-5">
          <div class="col-10">
              <h3>Keeps</h3>
              <div class="masonry-container">
                  <div v-for="keep in keeps" :key="keep.id" class="position-relative">
                      <KeepCard :keep="keep"/>
                  </div>
              </div>
          </div>
      </section>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
import {vaultsService} from '../services/VaultsService'
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';

export default {
  setup() {
      watchEffect(() => {
          AppState.account;
          getMyVaults();
          getMyKeeps();
      });
      
      async function getMyVaults() {
          try {
              await vaultsService.getMyVaults();
          }
          catch (error) {
              Pop.error(error);
          }
      }
      async function getMyKeeps() {
            try {
                await keepsService.getKeepsByProfile();
            }
            catch (error) {
                Pop.error(error);
            }
        }
      return {
        account: computed(() => AppState.account),
        vaults: computed(() => AppState.myVaults),
        keeps: computed(() => AppState.myKeeps),
        coverImg: computed(() => `url('${AppState.account.coverImg}')`)
        };
      },
      components: { VaultCard }
    };
  </script>


<style lang="scss" scoped>
.bg-cover{
  height: 35dvh;
  border-radius: 1rem;
  background-image: v-bind(coverImg);
  background-position: center;
  background-size: cover;
}
.profile-pic{
  position: absolute;
  bottom: -4.5dvh;
  left: 50%;
  transform: translateX(-50%);
  height: 10dvh;
  width: 10dvh;
  border-radius: 5rem;
  filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}

.masonry-container{
$gap: 1.25em;
columns: 15dvw;
column-gap: $gap;
div{
  margin-bottom: $gap;
}
}
@media screen and (max-width: 768px){
 .masonry-container{
  columns: 35dvw;
 }
}
</style>
