 <template>
  <div class="p-grid p-fluid dashboard">
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #007be5; color: #00448f">
          <span>T</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>No. of Tenat</span>
          <span class="count">20</span>
        </div>
      </div>
    </div>
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #ef6262; color: #a83d3b">
          <span>A</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>No. of Apartment</span>
          <span class="count">4</span>
        </div>
      </div>
    </div>
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #20d077; color: #038d4a">
          <span>O</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>No. of owner</span>
          <span class="count">7</span>
        </div>
      </div>
    </div>

    <div class="p-col-12 p-lg-8">
      <Panel header="Select Your Items" style="height: 100%"  class="gray">
        <!-- <div class="p-grid p-nogutter">
          <div v-for="(dressType, index) in dressTypes" :key="index">
            <a @click="activeFn(index)">
              <img
                :src="`http://www.washapp.lk/images/category/${dressType.urlprefix.toLowerCase()}.png`"
              />
            </a>
          </div>
        </div> -->

        <div class="p-grid">
          <div
            class="p-lg-6 p-col-4 p-p-4 product"
            v-for="data in allItems"
            :key="data._id"
          >
            <div
              class="bg"
              :style="`background-image: url('${data.imageUrl}');`"
              alt="Shirt on Hanger"
            ></div>

            <div class="front">
              <div class="p-col-12 p-">
                <h3 class="head">{{ data.name }}</h3>
              </div>
              <div class="p-col-12">
                <span class="discription">
                  {{ String(data.selectedServices) }}
                </span>
              </div>
              <div class="p-grid p-p-4">
                <div class="p-col-6">
                  <span class="price">Rs.{{ data.price }}</span>
                </div>
                <div class="p-col-6">
                  <i
                    class="pi pi-minus-circle"
                    @click="minusFn(data.index)"
                  ></i>
                  <label class="quantity">{{ data.count }}</label>
                  <i class="pi pi-plus-circle" @click="plusFn(data.index)"></i>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Panel>
    </div>
    <div class="p-col-12 p-lg-4">
      <Panel header="Add To Card" style="height: 100%">
        <div
          class="p-grid"
          v-for="(data, arrayIndex) in addToCard"
          :key="data.index"
        >
          <div class="p-col-4">
            <img :src="data.imageUrl" height="50p" />
          </div>
          <div class="p-col-8">
            {{ data.name }} <span>Rs.{{ data.price }} </span>
            <label class="quantity"> * {{ data.count }}</label>
          </div>
          <div @click="removedFn(arrayIndex, data.index)">X</div>
        </div>
      </Panel>
    </div>
  </div>
</template>

<script>
import { GetAll } from "../service/DressService";

export default {
  data() {
    return {
      dressTypes: [
        {
          index: 0,
          name: "Tops",
          urlprefix: "tops",
          isActive: false,
        },
        {
          index: 1,
          name: "Bottoms",
          urlprefix: "trousers",
          isActive: false,
        },
        //  "Tops",
        //   "Bottoms",
        //   "Dress",
        //   "Suits",
        //   "Laundry",
        //   "Press Only",
        //   "Shop",
        //   "Nightwear",
        //   "Kids",
        //   "Uniform",
        //   "Accessories",
        //   "Bedding",
      ],
      allItems: [],
      addToCard: [],
    };
  },
  watch: {
    allItems: {
      deep: true,
      handler(val) {
        let allItem = val;

        this.addToCard = allItem.filter((x) => x.count > 0);
      },
    },
  },
  mounted() {
    this.initFn();
  },
  methods: {
    formatCurrency(value) {
      return value.toLocaleString("en-US", {
        style: "currency",
        currency: "USD",
      });
    },
    async initFn() {
      try {
        let { data } = await GetAll();
        this.allItems = data.data.map((x, index) => {
          return {
            ...x,
            count: 0,
            index: index,
          };
        });
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
    },
    minusFn(index) {
      let allItems = JSON.parse(JSON.stringify(this.allItems));
      allItems[index].count = allItems[index].count - 1;
      this.allItems = allItems;
    },
    plusFn(index) {
      let allItems = JSON.parse(JSON.stringify(this.allItems));
      allItems[index].count = allItems[index].count + 1;
      this.allItems = allItems;
    },
    removedFn(arrayIndex, index) {
      console.log(arrayIndex, index);
    },
    onSortChange(event) {
      console.log(event);
      const value = event.value.value;
      const sortValue = event.value;

      if (value.indexOf("!") === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
        this.sortKey = sortValue;
      } else {
        this.sortOrder = 1;
        this.sortField = value;
        this.sortKey = sortValue;
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.bg {
  height: 136px;
  position: relative;
  background-size: cover;
  border-radius: 20px;
  top: 50px;
  transition: transform 0.6s;
}
.gray {
  background-color: #0000ffa6;
}
.front {
  position: relative;
  border-radius: 20px;
  background-color: #0e0c0c;
  color: white;
  padding: 20px;
  height: 215px;
}

span.price {
  background-color: grey;
  padding: 10px;
  position: relative;
  border-radius: 10px;
}
i.pi.pi-minus-circle {
  margin: 6px;
}
i.pi.pi-plus-circle {
  margin: 5px;
}
span.quantity {
  margin: 5px;
}
.pi-minus-circle:hover {
  color: #0000ffa6;
}
.pi-plus-circle:hover {
  color: #0000ffa6;
}
/*--------------------------------------------------------------*/
.product-name {
  font-size: 1.5rem;
  font-weight: 700;
}

.product-description {
  margin: 0 0 1rem 0;
}

.product-category-icon {
  vertical-align: middle;
  margin-right: 0.5rem;
}

.product-category {
  font-weight: 600;
  vertical-align: middle;
}

::v-deep(.product-list-item) {
  display: flex;
  align-items: center;
  padding: 1rem;
  width: 100%;

  img {
    width: 150px;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
    margin-right: 2rem;
  }

  .product-list-detail {
    flex: 1 1 0;
  }

  .p-rating {
    margin: 0 0 0.5rem 0;
  }

  .product-price {
    font-size: 1.5rem;
    font-weight: 600;
    margin-bottom: 0.5rem;
    align-self: flex-end;
  }

  .product-list-action {
    display: flex;
    flex-direction: column;
  }

  .p-button {
    margin-bottom: 0.5rem;
  }
}

.product-badge {
  border-radius: 2px;
  padding: 0.25em 0.5rem;
  text-transform: uppercase;
  font-weight: 700;
  font-size: 12px;
  letter-spacing: 0.3px;

  &.status-instock {
    background: #c8e6c9;
    color: #256029;
  }

  &.status-outofstock {
    background: #ffcdd2;
    color: #c63737;
  }

  &.status-lowstock {
    background: #feedaf;
    color: #8a5340;
  }
}

::v-deep(.product-grid-item) {
  margin: 0.5em;
  border: 1px solid #dee2e6;

  .product-grid-item-top,
  .product-grid-item-bottom {
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  img {
    width: 75%;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
    margin: 2rem 0;
  }

  .product-grid-item-content {
    text-align: center;
  }

  .product-price {
    font-size: 1.5rem;
    font-weight: 600;
  }
}

@media screen and (max-width: 576px) {
  .product-list-item {
    flex-direction: column;
    align-items: center;

    img {
      width: 75%;
      margin: 2rem 0;
    }

    .product-list-detail {
      text-align: center;
    }

    .product-price {
      align-self: center;
    }

    .product-list-action {
      display: flex;
      flex-direction: column;
    }

    .product-list-action {
      margin-top: 2rem;
      flex-direction: row;
      justify-content: space-between;
      align-items: center;
      width: 100%;
    }
  }
}

@media screen and (max-width: 960px) {
  /deep/ .p-datatable {
    &.p-datatable-customers {
      .p-datatable-thead > tr > th,
      .p-datatable-tfoot > tr > td {
        display: none !important;
      }

      .p-datatable-tbody > tr {
        border-bottom: 1px solid #dee2e6;
        > td {
          text-align: left;
          display: flex;
          align-items: center;
          justify-content: center;
          border: 0 none !important;
          width: 100% !important;
          float: left;
          clear: left;
          border: 0 none;

          .p-column-title {
            padding: 0.4rem;
            min-width: 30%;
            display: inline-block;
            margin: -0.4rem 1rem -0.4rem -0.4rem;
            font-weight: bold;
          }

          .p-progressbar {
            margin-top: 0.5rem;
          }
        }
      }
    }
  }
}
</style>

