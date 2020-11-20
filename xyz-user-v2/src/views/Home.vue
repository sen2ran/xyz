<template>
  <AuthLayout>
    <div class="md:pl-16">
      <div
        class="ml-auto xl:-ml-16 mr-auto xl:pl-16 pt-16 xl:h-screen w-auto sm:w-4/5 xl:w-auto grid grid-cols-12 gap-6"
      >
        <div
          class="chat-box col-span-12 xl:col-span-12 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium pb-2">Dashboard</div>
          <Count />
          <OrderTable />
        </div>
      </div>
    </div>
  </AuthLayout>
</template>
<script>
import OrderTable from "./Home/OrderTable";
import Count from "./Home/Count";
import AuthLayout from "@/Layout/AuthLayout";
export default {
  name: "Home",
  components: {
    AuthLayout,
    OrderTable,
    Count,
  },
};
</script>
