<template>
  <div class="layout-topbar">
    <button
      class="p-link layout-menu-button"
      v-if="this.$route.meta.isSidebar"
      @click="onMenuToggle"
    >
      <span class="pi pi-bars"></span>
    </button>
    <h3 v-if="!this.$route.meta.isSidebar">XYZ</h3>
  </div>
</template>

<script>
export default {
  methods: {
    onMenuToggle(event) {
      this.$emit("menu-toggle", event);
    },
  },
};
</script>