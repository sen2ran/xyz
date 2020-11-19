<template>
  <div
    class="intro-y my-1 px-1 w-full md:w-1/2 lg:my-4 lg:px-4 lg:w-1/3 border-transparent zoom-in"
  >
    <article class="overflow-hidden rounded-lg shadow-lg m-2">
      <a href="#">
        <img
          alt="Placeholder"
          class="block h-auto w-full"
          :src="item.imageUrl"
        />
      </a>

      <header
        class="flex items-center justify-between leading-tight p-2 md:p-4"
      >
        <h1 class="text-lg">
          <a class="no-underline hover:underline text-black" href="#">
            {{ item.name }} (Rs.{{ item.price }})
          </a>
        </h1>
      </header>
      <p class="ml-2 text-xs mx-4">{{ String(item.selectedServices) }}</p>

      <footer class="flex items-center justify-between leading-none p-2 md:p-4">
        <button
          class="px-6 py-2 transition ease-in duration-200 uppercase rounded-full hover:bg-gray-800 hover:text-white border-2 border-gray-900 focus:outline-none"
          @click="$emit('minus-fn', item)"
        >
          -
        </button>
        <h1>{{ item.count }}</h1>
        <button
          class="px-6 py-2 transition ease-in duration-200 uppercase rounded-full hover:bg-gray-800 hover:text-white border-2 border-gray-900 focus:outline-none"
          @click="$emit('plus-fn', item)"
        >
          +
        </button>
      </footer>
    </article>
  </div>
</template>

<script>
export default {
  name: "singleItem",
  props: ["item"]
};
</script>
