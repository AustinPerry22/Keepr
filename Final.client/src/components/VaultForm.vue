<template>
    <form @submit.prevent="createVault" class="container-fluid">
        <section class="row justify-content-center">
            <div class="col-12">
                <label for="name">Vault Name</label>
                <input v-model="vaultData.name" type="text" class="form-control" max-length="255" required>
            </div>
            <div class="col-12">
                <label for="img">Vault Image URL</label>
                <input v-model="vaultData.img" type="url" class="form-control" max-length="1000" required>
            </div>
            <div class="col-12">
                <label for="description">Vault Description</label>
                <textarea v-model="vaultData.description" type="text" class="form-control" max-length="1000" rows="15" required></textarea>
            </div>
            <div class="col-12">
                <label for="isPrivate">Is this vault private?</label>
                <input v-model="vaultData.isPrivate" type="checkbox" name="isPrivate" default="unchecked">
            </div>
            <div class="col-4 text-center mt-3">
                <button class="btn btn-success">Create Vault</button>
            </div>
        </section>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService';
import { useRoute } from 'vue-router';
import { router } from '../router';
export default {
    setup(){
        const vaultData = ref({})
        const route = useRoute()
    return { 
        vaultData,
        async createVault()
        {
            try {
                Modal.getOrCreateInstance('#create-vault').hide()
                if(vaultData.value.isPrivate == null) vaultData.value.isPrivate = false
                await vaultsService.createVault(vaultData.value)
                vaultData.value = {}
                router.push({name: 'Vault', params: {vaultId: AppState.activeVault.id}})
            } catch (error) {
                Pop.error(error)
            }
        }
     }
    }
};
</script>


<style lang="scss" scoped>

</style>