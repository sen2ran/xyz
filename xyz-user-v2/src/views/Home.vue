<template>
  <AuthLayout>
    <div class="md:pl-16 fixed">
      <div
        class="ml-auto xl:-ml-16 mr-auto xl:pl-16 pt-16 xl:h-screen w-auto sm:w-4/5 xl:w-auto grid grid-cols-12 gap-6"
      >
        <div
          class="chat-box col-span-12 xl:col-span-8 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium pb-2">Dashboard</div>
          SAsddddddddddddddddddddddddddddddddddddddddddddddsdsdssssssssssssssssssssssssssssssssssssssssssssssssssssssss
          <div
            class="overflow-y-scroll scrollbar-hidden flex flex-wrap -mx-1 lg:-mx-4"
          ></div>
        </div>
        <div
          class="chat-box col-span-12 xl:col-span-4 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium">Add to Card</div>
        </div>
      </div>
    </div>
  </AuthLayout>
</template>
<script>
// import SingleAddToCard from "./Home/SingleAddToCard";
import AuthLayout from "@/Layout/AuthLayout";
export default {
  name: "Home",
  components: {
    AuthLayout
    // SingleAddToCard
  }
};
</script>
