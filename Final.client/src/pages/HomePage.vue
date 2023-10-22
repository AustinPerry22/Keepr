<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
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
import {AppState} from "../AppState"
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import {keepsService} from "../services/KeepsService"
import KeepCard from "../components/KeepCard.vue";

export default {
    setup() {
        onMounted(() => getAllKeeps());
        async function getAllKeeps() {
            try {
                await keepsService.getAllKeeps();
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            keeps: computed(() => AppState.allKeeps)
        };
    },
    components: { KeepCard }
}
</script>

<style scoped lang="scss">
.masonry-container{
  $gap: 1.25em;
  columns: 15dvw;
  column-gap: $gap;
  div{
    margin-bottom: $gap;
  }
}

</style>
