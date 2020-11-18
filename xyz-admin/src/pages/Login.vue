<template>
  <div class="p-d-flex p-jc-center card-center">
    <div class="card p-mr-2">
      <div class="p-d-flex-column p-jc-center" style="width: 500px">
        <h1>Login</h1>
        <div class="p-col-12">
          <div class="card p-fluid">
            <div class="p-field">
              <label for="name1">Email</label>
              <InputText id="name1" v-model="email" type="text" />
              <span>{{ emailError }}</span>
            </div>
            <div class="p-field">
              <label for="email1">Password</label>
              <div class="p-inputgroup">
                <InputText
                  id="email1"
                  v-model="password"
                  :type="isShowPassword ? 'text' : 'password'"
                />
                <Button
                  :icon="isShowPassword ? 'pi pi-eye-slash' : 'pi pi-eye'"
                  @click="showPassFn"
                />
                <!--  -->
              </div>
              <span>{{ passwordError }}</span>
            </div>
            <div class="p-field center">
              <Button
                :label="loginString"
                @click="loginFn"
                class="p-mr-2 p-mb-2"
              ></Button>
              <small style="color: red">{{ loginError }}</small>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Login } from "../service/LoginService";
export default {
  data() {
    return {
      email: null,
      emailError: null,
      password: null,
      passwordError: null,
      loginString: "Login",
      isShowPassword: false,
      loginError: null,
    };
  },
  methods: {
    async loginFn() {
      this.loginString = "Loading...";
      let payload = {
        email: this.email,
        password: this.password,
      };
      try {
        let { data } = await Login(payload);
        if (data.success) {
          localStorage.setItem("user", JSON.stringify(data.data));
          this.$store.dispatch("user/setUser", data.data);
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
      // setTimeout(() => {
      //   this.$router.push("/");
      //   this.loginString = "Login";
      // }, 2000);
    },
    showPassFn() {
      this.isShowPassword = !this.isShowPassword;
    },
  },
};
</script>

<style scoped>
.card-center {
  margin-top: 10rem !important;
  margin-bottom: 3rem !important;
}
</style>
