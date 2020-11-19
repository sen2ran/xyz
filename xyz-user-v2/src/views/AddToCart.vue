<template>
  <AuthLayout>
    <div class="md:pl-16 fixed">
      <div
        class="xl:-ml-16 mr-auto xl:pl-16 pt-16 xl:h-screen w-auto sm:w-4/5 xl:w-auto grid grid-cols-12 gap-6"
      >
        <div
          class="chat-box col-span-12 xl:col-span-8 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium pb-2">
            Select Item for Laundry 2 {{ searchVal }}
          </div>
          <div class="intro-y chat-input border flex items-center px-5 py-4">
            <textarea
              class="input w-full h-16 resize-none border-transparent px-5 py-3 focus:shadow-none truncate mr-3 sm:mr-0"
              rows="1"
              v-model="searchVal"
              placeholder="Search"
              autocomplete="off"
              spellcheck="false"
            ></textarea>
          </div>

          <div
            class="overflow-y-scroll scrollbar-hidden flex flex-wrap -mx-1 lg:-mx-4"
          >
            <template
              v-for="singleItem in filteredList"
              :key="singleItem.index"
            >
              <SingleDress
                :item="singleItem"
                @minusFn="minusFn"
                @plusFn="plusFn"
              />
            </template>
          </div>
        </div>
        <div
          class="chat-box col-span-12 xl:col-span-4 flex flex-col overflow-hidden xl:border-l xl:border-r p-6"
        >
          <div class="intro-y text-xl font-medium">Add to Card</div>

          <div v-if="addToCard.length == 0">Please Add items</div>

          <div
            class="flex justify-between border-b"
            v-if="addToCard.length > 0"
          >
            <div
              class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
            >
              Priority
            </div>
            <div
              class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
            >
              <input
                type="checkbox"
                v-model="isHigh"
                class="input input--switch border"
              />
            </div>
          </div>

          <div
            class="overflow-y-scroll scrollbar-hidden intro-y chat-input"
            v-if="addToCard.length > 0"
          >
            <div class="p-2">
              <p class="mb-6 italic"></p>

              <template v-for="singleItem in addToCard" :key="singleItem._id">
                <SingleAddToCard
                  :singleItem="singleItem"
                  @deleteFn="deleteFn"
                />
              </template>
              <div class="flex justify-between border-b">
                <div
                  class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
                >
                  Subtotal
                </div>
                <div
                  class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
                >
                  Rs {{ computedPrice.subtotal }}
                </div>
              </div>
              <div class="flex justify-between pt-4 border-b">
                <div
                  class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
                >
                  Priority : {{ isHigh ? "High" : "Normal" }}
                </div>
                <div
                  class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
                >
                  Rs. {{ isHigh ? 100 : "-" }}
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
                  Rs. {{ computedPrice.total }}
                </div>
              </div>
              <button
                class="flex justify-center w-full px-2 py-3 mt-6 font-medium text-white uppercase bg-gray-800 rounded-full shadow item-center hover:bg-gray-700 focus:shadow-outline focus:outline-none"
                @click="orderFn"
              >
                <span class="ml-2 mt-5px">Procceed to checkout</span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div
      class="modal-invite-friends modal overflow-y-auto"
      :class="isPayment ? 'show' : ''"
      id="invite-friends-modal"
      style="margin-top: 0px; margin-left: 0px; padding-left: 0px; z-index: 53"
    >
      <div class="modal__content p-4">
        <div class="intro-y text-lg font-medium">Checkout</div>
        <div
          class="modal__content__scrollable overflow-y-auto scrollbar-hidden -mx-4 px-4 mt-4"
        >
          <div class="intro-y pb-3">
            <div class="intro-y block">
              <div
                class="user-list__item relative flex items-center px-4 py-3 mt-4"
              >
                <div class="ml-2 overflow-hidden">
                  <div class="intro-y block">
                    <div
                      class="user-list__item cursor-pointer relative flex items-center zoom-in"
                    >
                      <div class="ml-2 overflow-hidden">
                        <a
                          href="javascript:;"
                          class="user-list__item__name font-medium"
                          >Hai ,{{ user.name }}</a
                        >
                      </div>
                    </div>
                  </div>

                  <div class="flex items-center text-xs py-2">
                    <div class="user-list__item__text truncate auth">
                      <input
                        type="text"
                        class="auth__input input input--lg w-full border block"
                        v-model="address"
                        placeholder="Enter The Address "
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="flex justify-between border-b">
              <div
                class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
              >
                Subtotal
              </div>
              <div
                class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
              >
                Rs {{ computedPrice.subtotal }}
              </div>
            </div>
            <div class="flex justify-between pt-4 border-b">
              <div
                class="lg:px-4 lg:py-2 m-2 text-lg lg:text-xl font-bold text-center text-gray-800"
              >
                Priority : {{ isHigh ? "High" : "Normal" }}
              </div>
              <div
                class="lg:px-4 lg:py-2 m-2 lg:text-lg font-bold text-center text-gray-900"
              >
                Rs. {{ isHigh ? 100 : "-" }}
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
                Rs. {{ computedPrice.total }}
              </div>
            </div>
          </div>
          <div class="user-list__action user-list__action--action -mx-4 px-4">
            <button class="button button--primary w-full" @click="paymentFn">
              Pay
            </button>
          </div>
        </div>
      </div>
    </div>
  </AuthLayout>
</template>
<script>
import AuthLayout from "@/Layout/AuthLayout";
import SingleDress from "./Home/SingleDress";
import SingleAddToCard from "./Home/SingleAddToCard";
import { GetAll, MakeOrder } from "../service/DressService";

import { mapGetters } from "vuex";

export default {
  name: "Orders",
  components: {
    SingleDress,
    SingleAddToCard,
    AuthLayout
  },
  data() {
    return {
      allItems: [],
      addToCard: [],
      isHigh: false,
      isPayment: false,
      address: null,
      searchVal: null
    };
  },
  mounted() {
    this.initFn();
  },
  computed: {
    ...mapGetters({
      user: "getUser"
    }),
    filteredList() {
      console.log(this.searchVal);
      if (this.searchVal) {
        return this.allItems.filter(item => {
          return this.searchVal.indexOf(item.name) > -1;
        });
      } else {
        return this.allItems;
      }
    },
    computedPrice() {
      let price = 0;
      for (let i = 0; i < this.addToCard.length; i++) {
        price = price + this.addToCard[i].count * this.addToCard[i].price;
      }
      let highPrice = this.isHigh ? 100 : 0;
      let total = price + highPrice;

      return {
        subtotal: price,
        total: total
      };
    }
  },
  methods: {
    async initFn() {
      try {
        let { data } = await GetAll();
        this.allItems = data.data.map((x, index) => {
          return {
            ...x,
            count: 0,
            index: index
          };
        });
      } catch (error) {
        console.log(error);
      }
    },
    minusFn(e) {
      let allItems = JSON.parse(JSON.stringify(this.allItems));
      allItems[e.index].count = allItems[e.index].count - 1;
      this.allItems = allItems;
      this.addToCardFn(e, false);
    },
    plusFn(e) {
      let allItems = JSON.parse(JSON.stringify(this.allItems));
      allItems[e.index].count = allItems[e.index].count + 1;
      this.allItems = allItems;
      this.addToCardFn(e, true);
    },
    addToCardFn(item, isPlus) {
      if (this.addToCard.length > 0) {
        let addToCard = JSON.parse(JSON.stringify(this.addToCard));
        let index = addToCard.findIndex(
          x => x.id == this.allItems[item.index].id
        );
        if (index >= 0) {
          addToCard[index].count = isPlus
            ? addToCard[index].count + 1
            : addToCard[index].count - 1;
        } else {
          addToCard.push({
            ...item,
            count: 1
          });
        }
        this.addToCard = addToCard;
      } else {
        this.addToCard.push({
          ...item,
          count: 1
        });
      }
    },
    deleteFn(e) {
      let addToCardIndex = this.addToCard.findIndex(x => x.id == e.id);
      let allItemsIndex = this.allItems.findIndex(x => x.id == e.id);

      this.addToCard.splice(addToCardIndex, 1);
      this.allItems[allItemsIndex].count = 0;

      console.log(addToCardIndex, allItemsIndex);
    },
    orderFn() {
      this.isPayment = true;
    },
    async paymentFn() {
      let payload = {
        userId: this.user.id,
        addToCard: this.addToCard.map(x => {
          let tmpX = { ...x };
          tmpX.dressId = x.id;
          delete x["id"];
          return tmpX;
        }),
        isHigh: this.isHigh,
        address: this.address,
        subtotal: this.computedPrice.subtotal,
        total: this.computedPrice.total
      };
      try {
        let { data } = await MakeOrder(payload);
        if (data.success) {
          this.isPayment = false;
          this.addToCard = [];
          this.isHigh = false;
          this.address = null;
        }
      } catch (error) {
        console.log(error);
      }
    }
  }
};
</script>
