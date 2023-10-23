<template>
    <div class="container-fluid">
        <section class="row justify-content-center position-relative mt-2">
            <div class="col-10 col-md-8 bg-cover text-center">
                <img :src="profile.picture" alt="" class="profile-pic">
            </div>
        </section>
        <section class="row mt-5 pt-3">
            <div class="col-12 text-center">
                <h2><b>{{ profile.name }}</b></h2>
                <h6>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</h6>
            </div>
        </section>
        <section class="row justify-content-center">
            <div class="col-10">
                <h3>Vaults</h3>
                <section class="row justify-content-center">
                    <div v-for="vault in vaults" :key="vault.id" class="col-md-2 col-6 g-3">
                        <VaultCard :vault="vault"/>
                    </div>
                </section>
            </div>
        </section>
        <section class="row justify-content-center mt-5">
            <div class="col-10">
                <h3>Keeps</h3>
                <div class="masonry-container">
                    <div v-for="keep in keeps" :key="keep.id" class="position-relative">
                        <KeepCard :keep="keep"/>
                    </div>
                </div>
            </div>
        </section>
    </div>
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
import KeepCard from '../components/KeepCard.vue';
import VaultCard from '../components/VaultCard.vue';

export default {
    setup() {
        const route = useRoute();
        onMounted(() => {
            getProfileById();
            getVaultsByProfile();
            getKeepsByProfile();
        });
        async function getProfileById() {
            try {
                await profilesService.getProfileById(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getVaultsByProfile() {
            try {
                await vaultsService.getVaultsByProfile(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getKeepsByProfile() {
            try {
                await keepsService.getKeepsByProfile(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            profile: computed(() => AppState.activeProfile),
            vaults: computed(() => AppState.profileVaults),
            keeps: computed(() => AppState.profileKeeps),
            coverImg: computed(() => `url('${AppState.activeProfile.coverImg}')`),
        };
    },
    components: { VaultCard }
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
    width: 10dvh;
    border-radius: 5rem;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
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
 .bg-cover{
    height: 22.5dvh;
 }
}
</style>