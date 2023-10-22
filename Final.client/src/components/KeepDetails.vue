<template>
    <section v-if="keep.id" class="row active-keep">
        <div class="col-6 bg-keep-img">
        </div>
        <div class="col-6 d-flex flex-column justify-content-between">
            <section class="row justify-content-center text-center">
                <div class="col-3">
                    <p><i class="mdi mdi-eye"></i> {{ keep.views }}</p>
                </div>
                <div class="col-3">
                    <p><i class="mdi mdi-alpha-k-box-outline"></i> {{ keep.kept }}</p>
                </div>
            </section>
            <section class="row">
                <h3 class="text-center">{{ keep.name }}</h3>
                <p>{{ keep.description }}</p>
            </section>
            <section class="row">
                <div class="col-6">
                    <!-- TODO dropdown and save -->
                    dropdown and save
                </div>
                <div class="col-6 d-flex">
                    <router-link :to="{name: 'Profile', params: {profileId: keep.creator.id}}">
                        <img :src="keep.creator.picture" alt="" class="profile-pic" data-bs-toggle="modal" data-bs-target="#active-keep">
                    </router-link>
                    <p class="pt-3">{{ keep.creator.name }}</p>
                </div>
            </section>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup(){
    return { 
        keep: computed(()=> AppState.activeKeep),
        keepImg: computed(()=> `url('${AppState.activeKeep.img}')`)
     }
    }
};
</script>


<style lang="scss" scoped>
.active-keep
{
    height: 85dvh;
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
    border-radius: 5rem;
    filter: drop-shadow(.15rem 0.15rem .1rem rgba(0, 0, 0, 0.397))
}
</style>