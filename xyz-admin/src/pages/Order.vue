<template>
  <div class="p-grid crud-demo">
    <div class="p-col-12">
      <div class="card">
        <Toast />
        <Toolbar class="p-mb-4">
          <template slot="left">
            <Button
              label="New"
              icon="pi pi-plus"
              class="p-button-success p-mr-2"
              @click="openNew"
            />
          </template>

          <template slot="right">
            <Button
              label="Export"
              icon="pi pi-upload"
              class="p-button-help"
              @click="exportCSV($event)"
            />
          </template>
        </Toolbar>

        <DataTable
          ref="dt"
          :value="orders"
          :selection.sync="selectedOrders"
          data-key="id"
          :paginator="true"
          :rows="10"
          :filters="filters"
          paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
          :rowsPerPageOptions="[5, 10, 25]"
          currentPageReportTemplate="Showing {first} to {last} of {totalRecords} products"
        >
          <template #header>
            <div class="table-header">
              <h5 class="p-m-0">Manage Products</h5>
              <span class="p-input-icon-left">
                <i class="pi pi-search" />
                <InputText
                  v-model="filters['global']"
                  placeholder="Search..."
                />
              </span>
            </div>
          </template>

          <Column field="id" header="ID" sortable></Column>
          <Column field="isHigh" header="Priority" sortable>
            <template #body="slotProps">
              <span
                v-if="slotProps.data.isHigh"
                class="product-badge status-instock"
                >High</span
              >
              <span
                v-if="!slotProps.data.isHigh"
                class="product-badge status-outofstock"
                >Normal</span
              >
            </template></Column
          >
          <Column field="address" header="Address" sortable></Column>
          <Column
            field="maintenancePerUnitDefaultPrice"
            header="Item Count"
            sortable
          >
            <template #body="slotProps">
              {{ slotProps.data.addToCard.length }}
            </template>
          </Column>
          <Column field="total" header="Total" sortable>
            <template #body="slotProps">
              Rs. {{ slotProps.data.total }}
            </template></Column
          >
          <Column header="Status" sortable>
            <!-- <template #body="slotProps">
              <Button
                icon="pi pi-window-maximize"
                class="p-button-rounded p-button-success p-mr-2"
                @click="unitFn(slotProps.data)"
              /> -->
            <template #body="slotProps">
              <span
                @click="statusChange(slotProps.data)"
                v-if="slotProps.data.status != 'Compeleted'"
                class="product-badge status-outofstock"
                >{{ slotProps.data.status }}</span
              >
              <span v-else class="product-badge status-instock"
                >Compeleted</span
              >
            </template>
            <!-- </template> -->
          </Column>
        </DataTable>
      </div>
    </div>
  </div>
</template>

<script>
import { GetAllOrders, ChangeStatus } from "../service/DressService";

export default {
  components: {},
  data() {
    return {
      isEdit: false,
      submitted: false,
      orders: [],
      isDialog: false,
      deleteIsDialog: false,
      deleteDialog: false,
      selectedOrders: null,
      filters: {},
    };
  },
  computed: {
    computedCities() {
      return this.cities.map((x) => {
        return {
          name: x,
          code: x,
        };
      });
    },
  },
  async mounted() {
    await this.initFn();
  },
  methods: {
    async initFn() {
      try {
        let { data } = await GetAllOrders();
        console.log(data);
        this.orders = data.data;
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
    },
    async statusChange(data1) {
      if (data1.staus != "Compeleted") {
        let payload = {
          id: data1.id,
          status: data1.status == "Neworder" ? "Pending" : "Compeleted",
        };
        let { data } = await ChangeStatus(payload);
        if (data.success) {
          this.initFn();
        }
      }
    },
    createId() {
      let id = "";
      var chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      for (var i = 0; i < 5; i++) {
        id += chars.charAt(Math.floor(Math.random() * chars.length));
      }
      return id.toUpperCase();
    },
    openNew() {
      this.submitted = false;
      this.isDialog = true;
      this.isEdit = false;
      this.apartment = {
        apartmentId: this.createId(),
        apartmentName: null,
        imageUrl: `https://robohash.org/${Number(new Date())}?set=set3`,
        noOfUnit: null,
        address: null,
        cityName: null,
        maintenancePerUnitDefaultPrice: null,
        latAndLon: [1234, 1244],
      };
    },
    hideDialog() {
      console.log(this.$refs);
      let element = this.$refs.autocomplete.$el;
      const google = window.google;
      this.autocomplete = new google.maps.places.Autocomplete(element);

      this.isDialog = false;
      this.submitted = false;
      this.isEdit = false;
    },
    exportCSV() {
      this.$refs.dt.exportCSV();
    },
    unitFn(data) {
      this.$router.push(`/apartment/${data.id}`);
    },
    updateUnitFn() {
      this.isUnit = true;
    },
  },
};
</script>

<style scoped lang="scss">
.table-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.product-image {
  width: 100px;
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
}

.p-dialog .product-image {
  width: 150px;
  margin: 0 auto 2rem auto;
  display: block;
}

.confirmation-content {
  display: flex;
  align-items: center;
  justify-content: center;
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
</style>
