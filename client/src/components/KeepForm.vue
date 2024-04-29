<template>
    <form @submit.prevent="createKeep" class="container-fluid">
        <section class="row justify-content-center">
            <div class="col-12">
                <label for="name">Keep Name</label>
                <input v-model="keepData.name" type="text" class="form-control" max-length="255" required>
            </div>
            <div class="col-12">
                <label for="img">Keep Image URL</label>
                <input v-model="keepData.img" type="url" class="form-control" max-length="1000" required>
            </div>
            <div class="col-12">
                <label for="description">Keep Description</label>
                <textarea v-model="keepData.description" type="text" class="form-control" maxlength="1000" rows="15" required></textarea>
            </div>
            <div class="col-4 text-center mt-3">
                <button class="btn btn-success" type="submit" title="Create The Keep">Create Keep</button>
            </div>
        </section>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import { Modal } from 'bootstrap';
import { useRoute } from 'vue-router';
export default {
    setup(){
        const keepData = ref({})
        const route = useRoute()
    return { 
        keepData,
        async createKeep()
        {
            try {
                Modal.getOrCreateInstance('#create-keep').hide()
                await keepsService.createKeep(keepData.value, route.name)
                keepData.value = {}
                Modal.getOrCreateInstance("#active-keep").show()
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