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
            placeholder="Email"
          />
          <input
            type="password"
            class="intro-y auth__input input input--lg w-full border block mt-4"
            placeholder="Password"
          />
        </div>
        <div class="intro-y mt-5 xl:mt-8 text-center xl:text-left">
          <button
            class="intro-y button button--lg button--primary w-full xl:mr-3"
          >
            Login
          </button>
          <button
            class="intro-y button button--lg button--secondary w-full border mt-3"
          >
            Sign up
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
