<template>
    <img :src="keep.img" alt="" class="img-fluid cover-img">
    <h5 class="title">{{ keep.name }}</h5>
    <!-- router link here -->
    <img :src="keep.creator.picture" alt="" class="profile-pic">
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from '../models/Keep';
export default {
    props: {keep: {type: Keep, required: true}},
    setup(props){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.cover-img{
    border-radius: .25rem;
    width: 100%;
}
.title{
    position: absolute;
    bottom: 1.75dvh;
    left: 1.25dvw;
    color: white;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))
}

.profile-pic{
    position: absolute;
    bottom: 1.25dvh;
    right: .5dvw;
    height: 6dvh;
    border-radius: 5rem;
    filter: drop-shadow(.25rem 0.25rem .1rem rgba(0, 0, 0, 0.397))

}
</style>