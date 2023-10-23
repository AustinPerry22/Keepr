<template>
    <form @submit.prevent="editAccount" class="container-fluid">
        <section class="row justify-content-center">
            <div class="col-12">
                <label for="name">Name</label>
                <input v-model="accountData.name" type="text" class="form-control" max-length="255">
            </div>
            <div class="col-12">
                <label for="img">Profile Picture</label>
                <input v-model="accountData.picture" type="url" class="form-control" max-length="255">
            </div>
            <div class="col-12">
                <label for="img">Cover Picture</label>
                <input v-model="accountData.coverImg" type="url" class="form-control" max-length="1000">
            </div>
            <div class="col-4 text-center mt-3">
                <button title="save the changes to your account" type="button" class="btn btn-success">Save Changes</button>
            </div>
        </section>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
import { accountService } from '../services/AccountService';
export default {
    setup(){
        const accountData = ref({})
    return { 
        accountData,
        account: computed(()=> AppState.account),
        async editAccount(){
            try {
                Modal.getOrCreateInstance('#edit-account').hide()
                await accountService.editAccount(accountData.value)
                accountData.value = {}
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