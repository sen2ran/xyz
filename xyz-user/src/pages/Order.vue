<template>
  <div class="p-grid crud-demo">
    <div class="p-col-12">
      <div class="card">
        <Toast />
        <Toolbar class="p-mb-4">
          <template slot="left">
            <Button label="New" icon="pi pi-plus" class="p-button-success p-mr-2" @click="openNew" />
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
          :value="apartments"
          :selection.sync="selectedApartments"
          data-key="id"
          :paginator="true"
          :rows="10"
          :filters="filters"
          paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
          :rowsPerPageOptions="[5,10,25]"
          currentPageReportTemplate="Showing {first} to {last} of {totalRecords} products"
        >
          <template #header>
            <div class="table-header">
              <h5 class="p-m-0">Manage Products</h5>
              <span class="p-input-icon-left">
                <i class="pi pi-search" />
                <InputText v-model="filters['global']" placeholder="Search..." />
              </span>
            </div>
          </template>

          <Column field="apartmentId" header="ID" sortable></Column>
          <Column field="apartmentName" header="Name" sortable></Column>
          <!-- <Column header="Image">
            <template #body="slotProps">
              <img
                :src="'assets/layout/images/product/' + slotProps.data.image"
                :alt="slotProps.data.image"
                class="product-image"
              />
            </template>
          </Column>-->

          <Column field="address" header="Address" sortable></Column>
          <Column field="maintenancePerUnitDefaultPrice" header="Maintenance" sortable></Column>
          <Column field="noOfUnit" header="Total Units" sortable></Column>
          <Column>
            <template #body="slotProps">
              <Button
                icon="pi pi-window-maximize"
                class="p-button-rounded p-button-success p-mr-2"
                @click="unitFn(slotProps.data)"
              />
              <Button
                icon="pi pi-pencil"
                class="p-button-rounded p-button-success p-mr-2"
                @click="editProduct(slotProps.data)"
              />
              <Button
                icon="pi pi-trash"
                class="p-button-rounded p-button-warning"
                @click="confirmDeleteProduct(slotProps.data)"
              />
            </template>
          </Column>
        </DataTable>

        <Dialog
          :visible.sync="isDialog"
          :style="{width: '700px' , height: '800px'}"
          header="Apartment Details"
          :modal="true"
          class="p-fluid"
        >
          <div class="p-field">
            <label for="name">Apartment Name</label>
            <InputText
              id="name"
              v-model.trim="apartment.apartmentName"
              required="true"
              autofocus
              :class="{'p-invalid': submitted && !apartment.apartmentName}"
            />
            <small class="p-invalid" v-if="submitted && !apartment.apartmentName">Name is required.</small>
          </div>
          <div class="p-formgrid p-grid">
            <div class="p-field p-col-4">
              <label for="name">City Name</label>
              <Dropdown
                v-model="apartment.cityName"
                :options="computedCities"
                optionLabel="name"
                placeholder="Select a city"
              />
              <small class="p-invalid" v-if="submitted && !admin.role">Role is required.</small>
            </div>
            <div class="p-field p-col-8">
              <label for="name">Address</label>
              <InputText
                id="store-address-main-input"
                v-model.trim="apartment.address"
                required="true"
                placeholder="Street &amp; City"
                aria-label="Street &amp; City"
                ref="autocomplete"
                type="text"
                :class="{'p-invalid': submitted && !apartment.address}"
              />
              <small class="p-invalid" v-if="submitted && !apartment.address">Name is required.</small>
            </div>
          </div>

          <GoogleLocation />

          <div class="p-formgrid p-grid">
            <div class="p-field p-col">
              <label for="price">No Of Unit</label>
              <InputNumber id="price" v-model="apartment.noOfUnit" integeronly />
              <!-- mode="currency"
                currency="USD"
              locale="en-US"-->
            </div>
            <div class="p-field p-col">
              <label for="quantity">Maintenance Per Unit</label>
              <InputNumber
                id="maintenancePerUnitDefaultPrice"
                v-model="apartment.maintenancePerUnitDefaultPrice"
              />
            </div>
          </div>

          <template #footer>
            <Button label="Cancel" icon="pi pi-times" class="p-button-text" @click="hideDialog" />
            <Button label="Save" icon="pi pi-check" class="p-button-text" @click="saveApartment" />
          </template>
        </Dialog>
      </div>
    </div>
  </div>
</template>

<script>
import GoogleLocation from "../components/GoogleLocation";
import { AddApartment, GetAll } from "../service/ApartmentService";

export default {
  components: {
    GoogleLocation,
  },
  data() {
    return {
      apartment: {
        apartmentId: null,
        apartmentName: null,
        imageUrl: `https://robohash.org/${Number(new Date())}?set=set3`,
        noOfUnit: null,
        address: null,
        cityName: null,
        maintenancePerUnitDefaultPrice: null,
        latAndLon: [null, null],
      },

      street_number: null, //Street
      sublocality_level_1: null, //Sub Locality
      locality: null, //City
      administrative_area_level_2: null, //District
      administrative_area_level_1: null, //State Province
      postal_code: null, //Zip code
      country: null, //Country

      autocomplete: null,
      isUnit: false,
      cities: [
        "Kandy",
        "Matale",
        "Nuwara Eliya",
        "Ampara",
        "Batticaloa",
        "Trincomalee",
        "Anuradhapura",
        "Polonnaruwa",
        "Jaffna",
        "Kilinochchi",
        "Mannar",
        "Mulativu",
        "Vavuniya",
        "Kurunegala",
        "Chilaw",
        "Kegalle",
        "Ratnapura",
        "Galle",
        "Hambantota",
        "Matara",
        "Badulla",
        "Monaragala",
        "Colombo",
        "Gampaha",
        "Kalutara",
      ],
      isEdit: false,
      submitted: false,
      apartments: [],
      isDialog: false,
      deleteIsDialog: false,
      deleteDialog: false,
      selectedApartments: null,
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
        let { data } = await GetAll();
        console.log(data);
        this.apartments = data.data;
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
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
    async saveApartment() {
      let payload = {
        apartmentId: this.createId(),
        apartmentName: this.apartment.apartmentName,
        noOfUnit: this.apartment.noOfUnit,
        address: this.apartment.address,
        cityName: this.apartment.cityName.name,
        maintenancePerUnitDefaultPrice: this.apartment
          .maintenancePerUnitDefaultPrice,
        latAndLon: this.apartment.latAndLon,
      };
      console.log(payload);
      console.log(payload.latAndLon.length);
      console.log(payload.noOfUnit);
      console.log(this.apartment.cityName);
      // if (!this.isEdit) {
      if (
        payload.apartmentName &&
        payload.latAndLon.length > 0 &&
        payload.maintenancePerUnitDefaultPrice &&
        payload.noOfUnit > 0 &&
        payload.address &&
        payload.cityName
      ) {
        console.log(1);

        if (!this.isEdit) {
          try {
            console.log(2);

            let { data } = await AddApartment(payload);
            if (data.success) {
              this.$toast.add({
                severity: "success",
                summary: "Successful",
                detail: "Apartment Created",
                life: 5000,
              });
              this.isDialog = false;
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
              await this.initFn();
            }
          } catch (error) {
            this.$toast.add({
              severity: "error",
              summary: "Error",
              detail: error,
              life: 3000,
            });
          }
        }
      }
      // }
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
