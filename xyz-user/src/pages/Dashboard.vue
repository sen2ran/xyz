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
      <Panel header="Select Your Items" style="height: 100%">
        <DataView
          :value="allItems"
          :layout="layout"
          :paginator="true"
          :rows="9"
          :sortOrder="sortOrder"
          :sortField="sortField"
        >
          <template #header>
            <div class="p-grid p-nogutter">
              <div v-for="(dressType, index) in dressTypes" :key="index">
                <a @click="activeFn(index)">
                  <img
                    :src="`http://www.washapp.lk/images/category/${dressType.urlprefix.toLowerCase()}.png`"
                  />
                </a>
              </div>
            </div>
          </template>

          <template #list="slotProps">
            <div class="p-col-6 p-p-4 product">
              <div
                class="bg"
                :style="`background-image: url('${slotProps.data.imageUrl}');`"
                alt="Shirt on Hanger"
              ></div>

              <div class="front">
                <h1 class="head" data-v-1d81e2c0="">Shirt on Hanger</h1>
                <span class="discription" data-v-1d81e2c0="">
                  Washed Pressed and Hung,ironed and folded
                </span>

                <span class="price" data-v-1d81e2c0="">Rs.100</span>
                <span class="addToCart"></span>
              </div>
            </div>
            <!-- <div class="p-col-12 p-p-4">
              <div class="p-col-4">
                <img
                  style="height: 100px"
                  :src="slotProps.data.imageUrl"
                  :alt="slotProps.data.name"
                />
              </div>
              <div class="p-col-8">
                <h1>{{ slotProps.data.name }}</h1>
                <span>
                  {{ String(slotProps.data.selectedServices) }}
                </span>
              </div>
            </div> -->
          </template>
        </DataView>
      </Panel>
    </div>
    <div class="p-col-12 p-lg-4">
      <Panel header="Add To Card" style="height: 100%"> </Panel>
    </div>
  </div>
</template>

<script>
import { GetAll } from "../service/DressService";

export default {
  data() {
    return {
      layout: "list",
      sortKey: null,
      sortOrder: null,
      sortField: null,
      sortOptions: [
        { label: "Price High to Low", value: "!price" },
        { label: "Price Low to High", value: "price" },
      ],

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
      //
      tasksCheckbox: [],
      allItems: [],
      dropdownCities: [
        { name: "New York", code: "NY" },
        { name: "Rome", code: "RM" },
        { name: "London", code: "LDN" },
        { name: "Istanbul", code: "IST" },
        { name: "Paris", code: "PRS" },
      ],
      dropdownCity: null,
      events: null,
      products: null,
      selectedProducts: null,
      lineData: {
        labels: [
          "January",
          "February",
          "March",
          "April",
          "May",
          "June",
          "July",
        ],
        datasets: [
          {
            label: "Maintance",
            data: [65, 59, 80, 81, 56, 55, 40],
            fill: false,
            backgroundColor: "#2f4860",
            borderColor: "#2f4860",
          },
          {
            label: "Rent",
            data: [28, 48, 40, 19, 86, 27, 90],
            fill: false,
            backgroundColor: "#00bb7e",
            borderColor: "#00bb7e",
          },
        ],
      },
    };
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
        this.allItems = data.data;
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
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

.front {
  position: relative;
  border-radius: 20px;
  background-color: #0e0c0c;
  color: white;
  padding: 20px;
  top: -39px;
  height: 166px;
  left: -22px;
}

.product:hover .bg {
  transform: translate(20px, -40px);
}

span.price {
  background-color: grey;
  padding: 10px;
  position: relative;
  top: 21px;
  border-radius: 10px;
}
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

