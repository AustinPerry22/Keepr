<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <div class="masonry-container">
          <div v-for="keep in keeps" :key="keep.id">

            <img  :src="keep.img" alt="" class="img-fluid">
          </div>
        </div>

      </div>
    </section>
  </div>
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
.masonry-container{
  $gap: 1.25em;
  columns: 200px;
  column-gap: $gap;
  div{
    border-radius: 10px;
    width: 100%;
    margin-bottom: $gap;
  }
}
</style>
