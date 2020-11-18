<template>
  <div class="layout-profile">
    <div>
      <img width="200" :src="`https://robohash.org/${user.id}?set=set3`" alt />
    </div>
    <button class="p-link layout-profile-link" @click="onClick">
      <span class="username">{{user.name}}</span>
      <i class="pi pi-fw pi-cog"></i>
    </button>
    <transition name="layout-submenu-wrapper">
      <ul v-show="expanded">
        <li>
          <button class="p-link" @click="logoutFn">
            <i class="pi pi-fw pi-power-off"></i>
            <span>Logout</span>
          </button>
        </li>
      </ul>
    </transition>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  data() {
    return {
      expanded: false,
    };
  },
  computed: {
    ...mapGetters({
      user: "user/getUser",
    }),
  },
  methods: {
    onClick(event) {
      this.expanded = !this.expanded;
      event.preventDefault();
    },
    logoutFn() {
      localStorage.clear();
      location.href = "/login";
      // this.$router.push("/login");
    },
    settingFn() {
      this.$router.push("/setting");
    },
  },
};
</script>

<style scoped>
</style>