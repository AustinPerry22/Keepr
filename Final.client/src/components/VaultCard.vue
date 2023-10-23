<template>
    <section class="row justify-content-center">
        <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}">
            <div class="col-11 bg-vault elevation-3 rounded selectable d-flex flex-column justify-content-between">
                <h5>{{ vault.name }}</h5>
                <h5 v-if="vault.isPrivate" class="text-end me-2"><i class="mdi mdi-lock"></i></h5>
            </div>
        </router-link>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Vault } from '../models/Vault';
export default {
    props: { vault: { type: Vault, required: true } },
    setup(props){
    return { 
        vaultImg: computed(()=> `url('${props.vault.img}')`)
     }
    }
};
</script>


<style lang="scss" scoped>
.bg-vault{
    background-image: v-bind(vaultImg);
    background-position: center;
    background-size: cover;
    height: 20dvh;
}
h5{
    color: white;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}
</style>