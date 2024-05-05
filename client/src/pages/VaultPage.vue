<template>
    <div v-if="vault.id" class="container-fluid">
        <section class="row justify-content-center text-center mt-3">
            <div class="col-md-5 col-10 bg-vault-img d-flex flex-column justify-content-end">
                <h2>{{ vault.name }}</h2>
                <h4>by {{ vault.creator.name }}</h4>
            </div>
        </section>
        <section v-if="vault.creatorId == accountId" class="row justify-content-end my-2">
            <div class="col-6 col-md-3 text-end">
                <button @click="deleteVault()" type="button" title="delete the vault" class="btn btn-danger">Delete Vault</button>
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
        <section v-if="vault.creatorId == accountId" class="row justify-content-center">
            <div class="col-6 text-center">
                <router-link :to="{name: 'Home'}" title="Add Keeps">
                    <button class="btn btn-success w-50">Add Keeps</button>
                </router-link>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, watchEffect} from 'vue';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService';
import { router } from '../router';
import { onAuthLoaded } from '@bcwdev/auth0provider-client';
export default {
    setup(){
        const route = useRoute();
        onAuthLoaded(()=>{
            AppState.activeVault = {}
            getVaultById();
            getVaultKeeps()
        })
        watchEffect(()=>
        {
            route.params.vaultId,
            AppState.vaultKeeps = []
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
        accountId: computed(()=> AppState.account.id),
        vault: computed(()=> AppState.activeVault),
        keeps: computed(()=> AppState.vaultKeeps),
        vaultImg: computed(()=> `url('${AppState.activeVault.img}')`),

        async deleteVault()
        {
            try {
                if(await Pop.confirm("Are you sure you want to delete this vault"))
                {
                    await vaultsService.deleteVault()
                    router.push({name: 'Home'})
                    Pop.success("Vault Deleted")
                }
            } catch (error) {
                Pop.error(error)
            }
        }
     }
    }
};
</script>


<style lang="scss" scoped>
.bg-vault-img{
    background-image: v-bind(vaultImg);
    background-position: center;
    background-size: cover;
    height: 40dvh;
    border-radius: 1rem;
    h2,h4{
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
@media screen and (max-width: 768px){
 .masonry-container{
  columns: 35dvw;
 }
}
</style>