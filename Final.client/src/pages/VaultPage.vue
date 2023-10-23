<template>
    <div v-if="vault.id" class="container-fluid">
        <section class="row justify-content-center text-center mt-3">
            <div class="col-5 bg-vault-img d-flex flex-column justify-content-end">
                <h2>{{ vault.name }}</h2>
                <h6>by {{ vault.creator.name }}</h6>
            </div>
        </section>
        <section class="row justify-content-center">
            <div class="col-3 text-center">
                <h5 v-if="keeps.length == 0">No Keeps Yet</h5>
                <h5 v-if="keeps.length == 1">1 Keep</h5>
                <h5 v-if="keeps.length > 1">{{ keeps.length }} Keeps</h5>
            </div>
        </section>
        <section class="row justify-content-center">
            <div class="col-10">
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
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService';
import { router } from '../router';
export default {
    setup(){
        const route = useRoute();
        onMounted(()=>{
            getVaultById();
            getVaultKeeps()
        })
        async function getVaultById()
        {
            try {
                await vaultsService.getVaultById(route.params.vaultId)
            } catch (error) {
                Pop.error(error)
                router.push({name: 'Home'})
            }
        }
        async function getVaultKeeps()
        {
            try {
                await keepsService.getVaultKeeps(route.params.vaultId)
            } catch (error) {
                Pop.error(error)
            }
        }
    return { 
        vault: computed(()=> AppState.activeVault),
        keeps: computed(()=> AppState.vaultKeeps),
        vaultImg: computed(()=> `url('${AppState.activeVault.img}')`)
     }
    }
};
</script>


<style lang="scss" scoped>
.bg-vault-img{
    background-image: v-bind(vaultImg);
    background-position: center;
    background-size: cover;
    height: 25dvh;
    border-radius: 1rem;
    h2,h6{
        color: white;
        filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
    }
}
.masonry-container{
  $gap: 1.25em;
  columns: 15dvw;
  column-gap: $gap;
  div{
    margin-bottom: $gap;
  }
}
</style>