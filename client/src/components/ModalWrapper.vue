<template>
    <div class="modal fade" :id="id" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-xl" role="document">
        <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body text-dark">
            <slot name="body">

            </slot>
        </div>
        </div>
    </div>
    </div>
</template>

<script>

export default {
    props: {id: {type: String, required: true}, showButton: {type: Boolean, default: true}},
setup() {
  return {
  };
},
};
</script>


<style lang="scss" scoped>
.modal-header{
color: white;
background-color: #527360;
}
.modal-body{
    background-color: white;
}
</style>