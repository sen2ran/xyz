<template>
  <div class="w-full min-h-screen p-5 md:p-20 flex items-center justify-center">
    <div class="intro-y auth">
      <img
        class="intro-y mx-auto w-16"
        alt="Topson Messenger Tailwind HTML Admin Template"
        src="@/assets/logo.svg"
      />
      <div class="intro-y auth__title text-2xl font-medium text-center mt-16">
        Register New Account
      </div>
      <div class="intro-y box px-5 py-8 mt-8">
        <div class="intro-y">
          <input
            type="text"
            class="intro-y auth__input input input--lg w-full border block"
            v-model="name"
            placeholder="Fulll Name"
          />
          <div class="pb-2 text-center">
            <span class="text-sm text-red-700">{{ nameError }}</span>
          </div>
          <input
            type="text"
            class="intro-y auth__input input input--lg w-full border block mt-4"
            v-model="email"
            placeholder="Email"
          />
          <div class="pb-2 text-center">
            <span class="text-sm text-red-700">{{ emailError }}</span>
          </div>
          <input
            type="password"
            v-model="password"
            class="intro-y auth__input input input--lg w-full border block mt-4"
            placeholder="Password"
          />
          <div class="pb-2 text-center">
            <span class="text-sm text-red-700">{{ passwordError }}</span>
          </div>
        </div>

        <div class="intro-y mt-5 xl:mt-8 text-center xl:text-left">
          <button
            class="intro-y button button--lg button--primary w-full xl:mr-3"
            @click="regFn"
          >
            {{ regString }}
          </button>
          <button
            class="intro-y button button--lg button--secondary w-full border mt-3"
            @click="routeFn"
          >
            Sign in
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Registration } from "../service/LoginService";

export default {
  name: "SignUp",
  data() {
    return {
      name: null,
      nameError: null,
      email: null,
      emailError: null,
      password: null,
      passwordError: null,
      regString: "Registration",
      isShowPassword: false,
      loginError: null,
    };
  },
  methods: {
    async regFn() {
      this.regString = "Loading...";
      let payload = {
        name: this.name,
        email: this.email,
        password: this.password,
      };
      try {
        let { data } = await Registration(payload);
        if (data.success) {
          localStorage.setItem("user", JSON.stringify(data.data));
          this.$store.dispatch("user/setUser", data.data);
          this.regString = "Registration";
          this.$router.push("/login");
        } else {
          this.loginError = data.message;
          setTimeout(() => {
            this.loginError = "";
            this.regString = "Registration";
          }, 2000);
        }
      } catch (error) {
        console.log(error);
      }
    },
    showPassFn() {
      this.isShowPassword = !this.isShowPassword;
    },
    routeFn() {
      this.$router.push("/login");
    },
  },
};
</script>
