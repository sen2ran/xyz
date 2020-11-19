<template>
  <AuthLayout>
    <div class="md:pl-16 fixed">
      <div
        class="ml-auto xl:-ml-16 mr-auto xl:pl-16 pt-16 xl:h-screen w-auto sm:w-4/5 xl:w-auto grid grid-cols-12 gap-6"
      >
        <div
          class="chat-box col-span-12 xl:col-span-8 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium pb-2">
            Select Item for Laundry
          </div>
          <div class="intro-y chat-input border flex items-center px-5 py-4">
            <textarea
              class="input w-full h-16 resize-none border-transparent px-5 py-3 focus:shadow-none truncate mr-3 sm:mr-0"
              rows="1"
              placeholder="Search"
              autocomplete="off"
              spellcheck="false"
            ></textarea>
          </div>
          <div
            class="overflow-y-scroll scrollbar-hidden flex flex-wrap -mx-1 lg:-mx-4"
          >
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
            <SingleDress />
          </div>
        </div>
        <div
          class="chat-box col-span-12 xl:col-span-4 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium">Add to Card</div>
          <div class="overflow-y-scroll  scrollbar-hidden intro-y chat-input">
            <div class="p-2">
              <p class="mb-6 italic">
                Shipping and additionnal costs are calculated based on values
                you have entered
              </p>
              <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard />
              <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard />
              <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard />
              <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard />

              <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard /> <SingleAddToCard />
              <SingleAddToCard />

              <SingleAddToCard />

              <div class="flex justify-between border-b">
                <div
                  class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
                >
                  Subtotal
                </div>
                <div
                  class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
                >
                  148,827.53€
                </div>
              </div>
              <div class="flex justify-between pt-4 border-b">
                <div
                  class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
                >
                  Tax
                </div>
                <div
                  class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
                >
                  2,976.55€
                </div>
              </div>
              <div class="flex justify-between pt-4 border-b">
                <div
                  class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
                >
                  Total
                </div>
                <div
                  class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
                >
                  17,859.3€
                </div>
              </div>
              <button
                class="flex justify-center w-full px-2 py-3 mt-6 font-medium text-white uppercase bg-gray-800 rounded-full shadow item-center hover:bg-gray-700 focus:shadow-outline focus:outline-none"
              >
                <span class="ml-2 mt-5px">Procceed to checkout</span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </AuthLayout>
</template>
<script>
import SingleDress from "./Home/SingleDress";
import SingleAddToCard from "./Home/SingleAddToCard";
import AuthLayout from "@/Layout/AuthLayout";
export default {
  name: "Home",
  components: {
    AuthLayout,
    SingleDress,
    SingleAddToCard,
  },
};
</script>
