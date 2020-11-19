<template>
  <div class="intro-y flex justify-between border-b px-4 zoom-in">
    <div class="p-2 w-24">
      <img :src="singleItem.imageUrl" alt="img product" />
    </div>
    <div class="flex-auto text-sm w-32 m-2">
      <div class="font-bold text-gray-800">{{ singleItem.name }}</div>
      <div class="text-gray-400">Qt: {{ singleItem.count }}</div>
    </div>
    <div class="flex flex-col w-18 font-medium items-end">
      <div
        class="w-4 h-4 mb-6 hover:bg-red-200 rounded-full cursor-pointer text-red-700"
        @click="$emit('delete-fn', singleItem)"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="100%"
          height="100%"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-trash-2"
        >
          <polyline points="3 6 5 6 21 6"></polyline>
          <path
            d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"
          ></path>
          <line x1="10" y1="11" x2="10" y2="17"></line>
          <line x1="14" y1="11" x2="14" y2="17"></line>
        </svg>
      </div>
      Rs.{{ singleItem.price }}
    </div>
  </div>
</template>

<script>
export default {
  name: "singleAddtoCard",
  props: ["singleItem"]
};
</script>
