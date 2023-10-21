<template>
  hi
  {{ keeps }}
</template>

<script>
import {AppState} from "../AppState"
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import {keepsService} from "../services/KeepsService"

export default {
  setup() {
    onMounted(()=> getAllKeeps())
    async function getAllKeeps()
    {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      keeps: computed(()=> AppState.allKeeps)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
