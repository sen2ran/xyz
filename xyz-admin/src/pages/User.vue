<template>
  <div class="p-grid crud-demo">
    <div class="p-col-12">
      <Toolbar class="p-mb-4">
        <template slot="right">
          <Button
            label="Export"
            icon="pi pi-upload"
            class="p-button-help"
            @click="exportCSV($event)"
          />
        </template>
      </Toolbar>
      <div class="card">
        <Toast />

        <DataTable
          ref="dt"
          :value="admins"
          :selection.sync="selectedAdmins"
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
              <h5 class="p-m-0">Manage User</h5>
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
          <Column field="email" header="Email" sortable></Column>
          <Column header="Approval">
            <template #body="slotProps">
              <span
                v-if="slotProps.data.isApproved"
                class="product-badge status-instock"
                @click="ApprovalUser(slotProps.data)"
                >Approved</span
              >
              <span
                v-if="!slotProps.data.isApproved"
                class="product-badge status-outofstock"
                @click="ApprovalUser(slotProps.data)"
                >Not Approved</span
              >
            </template>
          </Column>
          <Column header="Actions">
            <template #body="slotProps">
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
          :style="{ width: '450px', height: 'auto' }"
          header="Admin Details"
          :modal="true"
          class="p-fluid"
        >
          <div class="p-formgrid p-grid">
            <img style width="150" height="150" :src="admin.imageUrl" alt />
          </div>
          <div class="p-field">
            <label for="name">Name</label>
            <InputText
              id="name"
              v-model.trim="admin.name"
              required="true"
              autofocus
              :class="{ 'p-invalid': submitted && !name }"
            />
            <small class="p-invalid" v-if="submitted && !admin.name"
              >Name is required.</small
            >
          </div>
          <div class="p-field">
            <label for="name">Role</label>
            <Dropdown
              v-model="admin.role"
              :options="roleList"
              optionLabel="name"
              placeholder="Select a Role"
            />
            <small class="p-invalid" v-if="submitted && !admin.role"
              >Role is required.</small
            >
          </div>
          <div class="p-field">
            <label for="name">Email</label>
            <InputText
              id="name"
              v-model.trim="admin.email"
              required="true"
              autofocus
              :disabled="isEdit"
              :class="{ 'p-invalid': submitted && !name }"
            />
            <small class="p-invalid" v-if="submitted && !admin.email"
              >Email is required.</small
            >
          </div>

          <div class="p-field">
            <label for="name">Password</label>
            <InputText
              id="name"
              v-model.trim="admin.password"
              required="true"
              autofocus
              type="password"
              :class="{ 'p-invalid': submitted && !password }"
            />
            <small
              class="p-invalid"
              v-if="submitted && !isEdit && !admin.password"
              >password is required.</small
            >
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
              @click="saveAdmin"
            />
          </template>
        </Dialog>

        <Dialog
          :visible.sync="deleteDialog"
          :style="{ width: '450px' }"
          header="Confirm"
          :modal="true"
        >
          <div class="confirmation-content">
            <i
              class="pi pi-exclamation-triangle p-mr-3"
              style="font-size: 2rem"
            />
            <span v-if="admin">
              Are you sure you want to delete
              <b>{{ admin.name }}</b
              >?
            </span>
          </div>
          <template #footer>
            <Button
              label="No"
              icon="pi pi-times"
              class="p-button-text"
              @click="deleteDialog = false"
            />
            <Button
              label="Yes"
              icon="pi pi-check"
              class="p-button-text"
              @click="deleteFn"
            />
          </template>
        </Dialog>
      </div>
    </div>
  </div>
</template>

<script>
import { GetAll, DeleteUser, Approval } from "../service/UserService";

export default {
  data() {
    return {
      admin: {
        name: null,
        password: null,
        imageUrl: `https://robohash.org/${Number(new Date())}?set=set3`,
        role: { name: "Manager", code: "manager" },
        email: null,
      },
      isEdit: false,
      deleteDialog: false,
      submitted: false,
      role: null,
      roleList: [
        { name: "Super Admin", code: "superAdmin" },
        { name: "Admin", code: "admin" },
        { name: "Manager", code: "manager" },
      ],
      admins: [],

      isDialog: false,
      deleteIsDialog: false,
      selectedAdmins: null,
      filters: {},
    };
  },
  async mounted() {
    await this.initFn();
  },
  methods: {
    dateConverterFn(date) {
      return date.split("T")[0];
    },
    RoleFn(no) {
      if (no == 0) {
        return "Super Admin";
      } else if (no == 1) {
        return "Admin";
      } else {
        return "Manager";
      }
    },
    async initFn() {
      try {
        let { data } = await GetAll();
        console.log(data);
        this.admins = data.data;

        // this.admins.push({
        //   name: "Adnan",
        //   email: "adnan@gmail.com",
        // });
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
    },
    exportCSV() {
      this.$refs.dt.exportCSV();
    },
    openNew() {
      this.submitted = false;
      this.isDialog = true;
      this.isEdit = false;
      this.admin = {
        name: null,
        password: null,
        imageUrl: `https://robohash.org/${Number(new Date())}?set=set3`,
        role: null,
        email: null,
      };
    },
    hideDialog() {
      this.isDialog = false;
      this.submitted = false;
      this.isEdit = false;
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
        let { data } = await DeleteUser(this.admin._id);
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
    async ApprovalUser(el) {
      // Approval
      let padyload = {
        id: el._id,
        isApproved: !el.isApproved,
      };
      try {
        let { data } = await Approval(padyload);
        console.log(data);
        this.initFn();
      } catch (error) {
        console.log(error);
      }
    },
    confirmDelete(data) {
      this.deleteDialog = true;
      let tmp = JSON.parse(JSON.stringify(data));
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
