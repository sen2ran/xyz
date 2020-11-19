<template>
  <div class="w-full min-h-screen p-5 md:p-20 flex items-center justify-center">
    <div class="intro-y auth">
      <img
        class="intro-y mx-auto w-16"
        alt="Topson Messenger Tailwind HTML Admin Template"
        src="@/assets/logo.svg"
      />
      <div class="intro-y auth__title text-2xl font-medium text-center mt-16">
        Login to Your Account!
      </div>
      <div class="intro-y box px-5 py-8 mt-8">
        <div class="intro-y">
          <input
            type="text"
            class="intro-y auth__input input input--lg w-full border block"
            v-model="email"
            placeholder="Email"
          />
          <input
            type="password"
            class="intro-y auth__input input input--lg w-full border block mt-4"
            v-model="password"
            placeholder="Password"
          />
        </div>
        <div class="intro-y mt-5 xl:mt-8 text-center xl:text-left">
          <div class="pb-2 text-center">
            <span class="text-sm text-red-700">{{ loginError }}</span>
          </div>
          <button
            class="intro-y button button--lg button--primary w-full xl:mr-3"
            @click="loginFn"
          >
            {{ loginString }}
          </button>
          <button
            class="intro-y button button--lg button--secondary w-full border mt-3"
            @click="routeFn"
          >
            Sign up
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Login } from "../service/LoginService";

export default {
  name: "Login",
  data() {
    return {
      loginError: null,
      email: null,
      emailError: null,
      password: null,
      passwordError: null,
      loginString: "Login"
    };
  },
  methods: {
    routeFn() {
      this.$router.push("/sign-up");
    },
    async loginFn() {
      this.loginString = "Loading...";
      let payload = {
        email: this.email,
        password: this.password
      };
      try {
        let { data } = await Login(payload);
        if (data.success) {
          localStorage.setItem("user", JSON.stringify(data.data));
          this.$store.dispatch("setUser", data.data);
          this.$router.push("/");
          this.loginString = "Login";
        } else {
          this.loginError = data.message;
          setTimeout(() => {
            this.loginError = "";
            this.loginString = "Login";
          }, 2000);
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>
