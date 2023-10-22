<template>
    {{ keep }}
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup(){
    return { 
        keep: computed(()=> AppState.activeKeep)
     }
    }
};
</script>


<style lang="scss" scoped>

</style>