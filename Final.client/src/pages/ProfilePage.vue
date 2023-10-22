<template>
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
                logger.log("getting keeps by profile")
                await keepsService.getKeepsByProfile(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
    return { 
        profile: computed(()=> AppState.activeProfile),
        vaults: computed(()=> AppState.activeVaults),
        keeps: computed(()=> AppState.profileKeeps)
     }
    }
};
</script>


<style lang="scss" scoped>

</style>