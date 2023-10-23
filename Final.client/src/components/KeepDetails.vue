<template>
    <section v-if="keep.id" class="row active-keep">
        <div class="col-12 col-md-6 bg-keep-img">
        </div>
        <div class="col-12 col-md-6 d-flex flex-column justify-content-between"> 
            <section class="row justify-content-center text-center">
                <div class="col-3">
                    <p><i class="mdi mdi-eye"></i> {{ keep.views }}</p>
                </div>
                <div class="col-3">
                    <p><i class="mdi mdi-alpha-k-box-outline"></i> {{ keep.kept }}</p>
                </div>
                <div v-if="keep.creatorId==accountId" class="col-6 text-end">
                    <button @click="deleteKeep()" class="btn btn-danger">Delete Keep</button>
                </div>
            </section>
            <section class="row">
                <h3 class="text-center">{{ keep.name }}</h3>
                <p>{{ keep.description }}</p>
            </section>
            <section class="row justify-content-between">
                <div v-if="accountId" class="col-12 col-md-6 text-md-start text-center">
                    <div v-if="inMyVault">
                        <button @click="removeKeepFromVault()" class="btn btn-danger">Remove</button>
                    </div>
                    <div v-else>
                        <div v-if="accountId" class="dropdown">
                            <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Add to Vault
                            </button>
                            <ul class="dropdown-menu">
                                <li v-for="vault in vaults" :key="vault.id" @click="addKeepToVault(vault.id)"><a class="dropdown-item selectable">{{ vault.name }}</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 d-flex text-center">
                    <img @click="goToProfile()" :src="keep.creator.picture" alt="" class="profile-pic selectable" data-bs-toggle="modal" data-bs-target="#active-keep">
                    <p class="pt-3">{{ keep.creator.name }}</p>
                </div>
            </section>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { router } from '../router';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
import { keepsService } from '../services/KeepsService';
import { useRoute } from 'vue-router';
import { vaultsService } from '../services/VaultsService';
export default {
    setup(){
        const route = useRoute()
    return { 
        route,
        accountId: computed(()=> AppState.account.id),
        keep: computed(()=> AppState.activeKeep),
        vaults: computed(()=> AppState.myVaults),
        keepImg: computed(()=> `url('${AppState.activeKeep.img}')`),
        inMyVault: computed(()=>
        {
            if(!route.params.vaultId) return false
            if(AppState.account.id != AppState.activeVault.creatorId) return false
            return true
        }),
        goToProfile(){
            if(this.accountId == this.keep.creatorId)
            {
                router.push({name: 'Account'})
            } 
            else
            {
                router.push({name: 'Profile', params: {profileId: this.keep.creatorId}})
            }
        },
        async addKeepToVault(vaultId)
        {
            try {
                await keepsService.addKeepToVault(vaultId, this.keep.id)
                Pop.success("Added The Keep To Your Vault")
            } catch (error) {
                Pop.error(error)
            }
        },
        async removeKeepFromVault()
        {
            try {
                Modal.getOrCreateInstance('#active-keep').hide()
                await vaultsService.removeKeepFromVault(this.keep.id)
            } catch (error) {
                Pop.error(error)
            }
        },
        async deleteKeep(){
            try {
                if(await Pop.confirm("Are you sure you want to delete this keep?"))
                {
                    Modal.getOrCreateInstance('#active-keep').hide()
                    await keepsService.deleteKeep(this.keep.id, route.name)
                    Pop.success("Keep Deleted")
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
p{
    overflow-x:hidden;
}
.active-keep
{
    height: 77.5dvh;
}
.bg-keep-img
{
    background-image: v-bind(keepImg);
    background-position: center;
    background-size: cover;
    border-radius: .5rem;
}

.profile-pic{
    height: 6dvh;
    width: 6dvh;
    border-radius: 5rem;
    filter: drop-shadow(.15rem 0.15rem .1rem rgba(0, 0, 0, 0.397))
}
</style>