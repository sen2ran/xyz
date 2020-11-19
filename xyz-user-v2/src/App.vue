<template>
  <router-view />
</template>

<script>
export default {
  name: "App",
  mounted() {
    if (localStorage.getItem("user")) {
      this.$store.dispatch("setUser", JSON.parse(localStorage.getItem("user")));
    }
  },
};
</script>
