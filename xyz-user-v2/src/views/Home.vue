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
          <Count :count="count" />
          <OrderTable :orders="allOrder" />
        </div>
      </div>
    </div>
  </AuthLayout>
</template>
<script>
import OrderTable from "./Home/OrderTable";
import Count from "./Home/Count";
import AuthLayout from "@/Layout/AuthLayout";
import { getAllOrderByUser } from "../service/DressService";

export default {
  name: "Home",
  components: {
    AuthLayout,
    OrderTable,
    Count,
  },
  data() {
    return {
      allOrder: [],
      count: {
        count: 0,
        pending: 0,
        completed: 0,
        price: [{ total: 0 }],
      },
    };
  },
  mounted() {
    this.initFn();
  },
  methods: {
    async initFn() {
      try {
        let payload = {
          id: JSON.parse(localStorage.getItem("user")).id,
        };
        let { data } = await getAllOrderByUser(payload);

        this.allOrder = data.data;

        this.count.count = data.data.length;
        this.count.completed = data.data.filter(
          (x) => x.status == "Completed"
        ).length;
        this.count.pending = data.data.length - this.count.completed;

        this.count.price = data.data.reduce(function (acc, val) {
          var o = acc
            .filter(function (obj) {
              return obj.name == val.name;
            })
            .pop() || { name: val.name, total: 0 };

          o.total += val.total;
          acc.push(o);
          return acc;
        }, []);
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>
