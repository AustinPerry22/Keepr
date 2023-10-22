<template>
    profile page
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import {profilesService} from '../services/ProfilesService'
import Pop from '../utils/Pop';

export default {
    setup(){
        const route = useRoute()
        onMounted(()=> {
            getProfileById()
            // getVaultsByProfile()
            // getKeepsByProfile()
        })
        async function getProfileById()
        {
            try {
                await profilesService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
    return { 
        profile: computed(()=> AppState.activeProfile)
     }
    }
};
</script>


<style lang="scss" scoped>

</style>