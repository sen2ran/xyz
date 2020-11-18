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
        </Toolbar>

        <DataTable
          ref="dt"
          :value="owners"
          :selection.sync="selectedOwners"
          data-key="id"
          :paginator="true"
          :rows="15"
          :filters="filters"
          paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
          :rowsPerPageOptions="[5, 10, 25]"
          currentPageReportTemplate="Showing {first} to {last} of {totalRecords} Users"
        >
          <template #header>
            <div class="table-header">
              <h5 class="p-m-0">Manage Admin</h5>
              <span class="p-input-icon-left">
                <i class="pi pi-search" />
                <InputText
                  v-model="filters['global']"
                  placeholder="Search..."
                />
              </span>
            </div>
          </template>

          <Column field="name" header="Name" sortable></Column>
          <Column field="dressType" header="Dress Type" sortable></Column>
          <Column header="Services" sortable>
           <template #body="slotProps">
             {{String(slotProps.data.selectedServices)}}
           </template>
           </Column>
          <Column header="Image">
            <template #body="slotProps">
              <img
                :src="slotProps.data.imageUrl"
                height="75"
                :alt="slotProps.data.image"
              />
            </template>
          </Column>
          <Column header="Actions">
            <template #body="slotProps">
              <Button
                icon="pi pi-pencil"
                class="p-button-rounded p-button-success p-mr-2"
                @click="editUser(slotProps.data)"
              />
              <Button
                icon="pi pi-trash"
                class="p-button-rounded p-button-warning"
                @click="confirmDelete(slotProps.data)"
              />
            </template>
          </Column>
        </DataTable>

        <Dialog
          :visible.sync="isDialog"
          :style="{ width: '1000px', height: '1000px' }"
          header="Add Dress Type Details"
          :modal="true"
          class="p-fluid"
        >
          <div class="p-formgrid p-grid">
            <div class="p-field p-col">
              <label for="name">Item Name</label>
              <InputText
                id="name"
                v-model.trim="name"
                required="true"
                autofocus
                :class="{ 'p-invalid': submitted && !owner.ownerName }"
              />
              <small class="p-invalid" v-if="submitted"
                >Name is required.</small
              >
            </div>
            <div class="p-field p-col">
              <label for="name">Item Type</label>
              <Dropdown
                v-model="dressType"
                :options="computedDressType"
                optionLabel="name"
                placeholder="Select a dress type"
              />
              <small class="p-invalid" v-if="submitted"
                >Role is required.</small
              >
            </div>
          </div>
          <div class="p-field">
            <label for="name">services</label>
            <MultiSelect
              v-model="selectedServices"
              :options="services"
              optionLabel="name"
              placeholder="Select Brands"
            />
          </div>
          <div class="p-formgrid p-grid">
            <div class="p-field p-col">
              <label for="price">Price</label>
              <InputNumber id="price" v-model="price" integeronly />
            </div>
            <div class="p-field p-col">
              <label for="quantity">Image Url</label>
              <InputText
                id="name"
                v-model.trim="imageUrl"
                required="true"
                autofocus
                :class="{ 'p-invalid': submitted && !owner.ownerName }"
              />
              <small class="p-invalid" v-if="submitted"
                >Name is required.</small
              >
            </div>
          </div>
          <div class="p-formgrid p-grid" style="height: 275px">
            <img style height="150" :src="imageUrl" alt />
          </div>
          <template #footer>
            <Button
              label="Cancel"
              icon="pi pi-times"
              class="p-button-text"
              @click="hideDialog"
            />
            <Button
              label="Save"
              icon="pi pi-check"
              class="p-button-text"
              @click="saveOwner"
            />
          </template>
        </Dialog>
      </div>
    </div>
  </div>
</template>

<script>
import { GetAll, DeleteUser, AddDress } from "../service/DressService";

export default {
  data() {
    return {
      dressTypes: [
        "Tops",
        "Bottoms",
        "Dress",
        "Suits",
        "Laundry",
        "Press Only",
        "Shop",
        "Nightwear",
        "Kids",
        "Uniform",
        "Accessories",
        "Bedding",
      ],
      services: [
        { name: "Washed Pressed and Hung", value: "Washed Pressed and Hung" },
        { name: "ironed and folded", value: "ironed and folded" },
        {
          name: "Carefully dry cleaned and hung",
          value: "Carefully dry cleaned and hung",
        },
        { name: "Dry/Care Cleaned", value: "Dry/Care Cleaned" },
        { name: "Washed and ironed", value: "Washed and ironed" },
        { name: "Denim Excluded. Washed", value: "Denim Excluded. Washed" },
        { name: "Ironed and folded", value: "Ironed and folded" },
        { name: "Carefully dry cleaned", value: "Carefully dry cleaned" },
        { name: "Washed", value: "Washed" },
      ],
      isEdit: false,
      deleteDialog: false,
      submitted: false,

      owners: [],

      isDialog: false,
      deleteIsDialog: false,
      selectedOwners: null,
      filters: {},

      name: null,
      dressType: null,
      price: null,
      imageUrl: null,
      selectedServices: [],
    };
  },
  computed: {
    computedDressType() {
      return this.dressTypes.map((x) => {
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
    dateConverterFn(date) {
      return date.split("T")[0];
    },
    async initFn() {
      try {
        let { data } = await GetAll();
        this.owners = data.data;
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
    },
    openNew() {
      this.submitted = false;
      this.isDialog = true;
      this.isEdit = false;
    },
    hideDialog() {
      this.isDialog = false;
      this.submitted = false;
      this.isEdit = false;
    },
    async saveOwner() {
      this.submitted = true;

      let payload = {
        name: this.name,
        dressType: this.dressType.name,
        price: this.price,
        imageUrl: this.imageUrl,
        selectedServices: this.selectedServices.map((x) => x.name),
      };

      try {
        let { data } = await AddDress(payload);
        if (data.success) {
          this.$toast.add({
            severity: "success",
            summary: "Successful",
            detail: "Dress Created",
            life: 3000,
          });
          this.isDialog = false;
          this.isEdit = false;

          await this.initFn();
        } else {
          this.$toast.add({
            severity: "success",
            summary: "Successful",
            detail: "Error",
            life: 3000,
          });
        }
      } catch (error) {
        this.$toast.add({
          severity: "success",
          summary: "Successful",
          detail: error,
          life: 3000,
        });
      }


    },
    editUser(data) {
      this.isEdit = true;
      let tmp = JSON.parse(JSON.stringify(data));
      tmp.role = this.roleList[data.role];
      tmp.password = null;

      this.admin = tmp;
      this.submitted = false;
      this.isDialog = true;
    },
    async deleteFn() {
      try {
        let { data } = await DeleteUser(this.admin.id);
        if (data.success) {
          this.$toast.add({
            severity: "success",
            summary: "Successful",
            detail: "User Deleted",
            life: 3000,
          });
          this.isDialog = false;
          this.isEdit = false;
          this.deleteDialog = false;
          this.admin = {
            name: null,
            password: null,
            imageUrl: `https://robohash.org/${Number(new Date())}?set=set3`,
            role: null,
            email: null,
          };
          await this.initFn();
        } else {
          this.$toast.add({
            severity: "error",
            summary: "Error",
            detail: "User Not Deleted",
            life: 3000,
          });

          await this.initFn();
        }
      } catch (error) {
        console.log(error);
      }
    },
    confirmDelete(data) {
      this.deleteDialog = true;
      let tmp = JSON.parse(JSON.stringify(data));
      console.log(tmp);
      this.admin = tmp;
      this.submitted = false;
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
