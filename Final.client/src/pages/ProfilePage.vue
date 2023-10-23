<template>
    <div class="container-fluid">
        <section class="row justify-content-center position-relative">
            <div class="col-8 bg-cover text-center">
                <img :src="profile.picture" alt="" class="profile-pic">
            </div>
        </section>
    </div>
    {{ profile }}
    {{ vaults }}
    {{ keeps }}
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import {profilesService} from '../services/ProfilesService'
import {vaultsService} from '../services/VaultsService'
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';
import { logger } from '../utils/Logger';

export default {
    setup(){
        const route = useRoute()
        onMounted(()=> {
            getProfileById()
            getVaultsByProfile()
            getKeepsByProfile()
        })
        async function getProfileById()
        {
            try {
                await profilesService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        async function getVaultsByProfile()
        {
            try {
                await vaultsService.getVaultsByProfile(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        async function getKeepsByProfile()
        {
            try {
                await keepsService.getKeepsByProfile(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
    return { 
        profile: computed(()=> AppState.activeProfile),
        vaults: computed(()=> AppState.activeVaults),
        keeps: computed(()=> AppState.profileKeeps),
        coverImg: computed(()=> `url('${AppState.activeProfile.coverImg}')`)
     }
    }
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
    border-radius: 5rem;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}
</style>