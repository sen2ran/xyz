<template>
  <!-- BEGIN: Top Bar -->
  <div class="top-bar top-0 left-0 fixed w-full h-16">
    <div class="top-bar__content border-b w-full h-full flex px-5">
      <!-- BEGIN: Logo -->
      <a class="hidden md:flex items-center h-full mr-auto">
        <img
          alt="Topson Messenger Tailwind HTML Admin Template"
          class="h-8"
          src="@/assets/logo.svg"
        />
        <div class="text-base font-light ml-4">
          <span class="font-medium">XYZ</span> Online Laundry Management
        </div>
      </a>
      <!-- END: Logo -->
      <a
        class="mobile-menu-toggler flex md:hidden items-center h-full mr-auto px-5 -ml-5"
        href="javascript:;"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-bar-chart-2 w-5 h-5 transform rotate-90"
        >
          <line x1="18" y1="20" x2="18" y2="10"></line>
          <line x1="12" y1="20" x2="12" y2="4"></line>
          <line x1="6" y1="20" x2="6" y2="14"></line>
        </svg>
      </a>
      <!-- BEGIN: Account -->
      <div class="account-dropdown dropdown relative">
        <a
          @click="isProfileSet = !isProfileSet"
          class="h-full dropdown-toggle flex items-center pl-5"
        >
          <div class="hidden md:block ml-3">
            <div class="w-24 truncate font-medium leading-tight">
              {{ user.name }}
            </div>
          </div>
        </a>
        <div
          class="dropdown-content dropdown-box absolute w-56 top-0 right-0 z-20"
          :class="isProfileSet ? 'show' : ''"
        >
          <div class="dropdown-box__content box">
            <div class="dropdown-content__footer p-2 border-t">
              <a
                @click="logoutFn()"
                class="flex items-center p-2 transition duration-300 ease-in-out rounded-md"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="1"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-toggle-right w-4 h-4 mr-2"
                >
                  <rect x="1" y="5" width="22" height="14" rx="7" ry="7"></rect>
                  <circle cx="16" cy="12" r="3"></circle>
                </svg>
                Logout
              </a>
            </div>
          </div>
        </div>
      </div>
      <!-- END: Account -->
    </div>
  </div>
  <div class="side-menu hidden md:block top-0 left-0 fixed w-16 h-screen">
    <div
      class="side-menu__content border-r w-full h-full pt-16 flex flex-col justify-center overflow-hidden"
    >
      <a
        class="-intro-x relative tooltip py-5 tooltipstered"
        @click="routFn('/')"
        data-side="right"
        data-content="chats"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-mail w-5 h-5 mx-auto"
        >
          <path
            d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"
          ></path>
          <polyline points="22,6 12,13 2,6"></polyline>
        </svg>
      </a>
      <a
        class="-intro-x relative tooltip py-5 tooltipstered"
        @click="routFn('/add-to-cart')"
        data-side="right"
        data-content="groups"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-edit w-5 h-5 mx-auto"
        >
          <path
            d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"
          ></path>
          <path
            d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"
          ></path>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5"
        @click="routFn('/order')"
        data-side="right"
        data-content="contacts"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-users w-5 h-5 mx-auto"
        >
          <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
          <circle cx="9" cy="7" r="4"></circle>
          <path d="M23 21v-2a4 4 0 0 0-3-3.87"></path>
          <path d="M16 3.13a4 4 0 0 1 0 7.75"></path>
        </svg>
      </a>
    </div>
  </div>
  <!-- END: Top Bar -->
  <slot></slot>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "AuthLayout",
  data() {
    return {
      isProfileSet: false
    };
  },
  computed: {
    ...mapGetters({
      user: "getUser"
    })
  },
  methods: {
    routFn(el) {
      this.$router.push(el);
    },
    logoutFn() {
      localStorage.clear();
      window.location.href = "/login";
    }
  }
};
</script>
