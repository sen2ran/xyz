import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "dashboard",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/Dashboard.vue"),
    },
    {
      path: "/dress-type",
      name: "dress-type",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/DressType.vue"),
    },
    {
      path: "/order",
      name: "order",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/Order.vue"),
    },

    {
      path: "/user",
      name: "user",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/User.vue"),
    },
    {
      path: "/user",
      name: "user",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/User.vue"),
    },
    {
      path: "/login",
      name: "login",
      meta: {
        isSidebar: false,
      },
      component: () => import("./pages/Login.vue"),
    },
    {
      path: "/register",
      name: "Registration",
      meta: {
        isSidebar: false,
      },
      component: () => import("./pages/Registration.vue"),
    },
    {
      path: "/admin",
      name: "Admin",
      meta: {
        isSidebar: true,
      },
      component: () => import("./pages/Admin.vue"),
    },
  ],
  scrollBehavior() {
    return { x: 0, y: 0 };
  },
});
