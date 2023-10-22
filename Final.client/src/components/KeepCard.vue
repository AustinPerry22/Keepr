<template>
    <img @click="openKeep(keep.id)" :src="keep.img" alt="" class="img-fluid cover-img selectable">
    <h5 class="title">{{ keep.name }}</h5>
    <router-link :to="{name: 'Profile', params: {profileId: keep.creator.id}}">
        <img :src="keep.creator.picture" alt="" class="profile-pic">
    </router-link>
    
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop';
export default {
    props: { keep: { type: Keep, required: true } },
    setup() {
        return {
            async openKeep(keepId) {
                try {
                    AppState.activeKeep = {};
                    await keepsService.getKeepById(keepId);
                    Modal.getOrCreateInstance('#active-keep').show();
                }
                catch (error) {
                    Pop.error(error);
                }
            }
        };
    },
};
</script>


<style lang="scss" scoped>
.cover-img{
    border-radius: .25rem;
    width: 100%;
}
.title{
    position: absolute;
    bottom: 1.75dvh;
    left: 1.25dvw;
    color: white;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}

.profile-pic{
    position: absolute;
    bottom: 1.25dvh;
    right: .5dvw;
    height: 6dvh;
    border-radius: 5rem;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}
</style>