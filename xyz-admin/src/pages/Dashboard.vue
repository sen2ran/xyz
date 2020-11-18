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
      <Panel header="Navigation" style="height: 100%">
        <div class="activity-header">
          <div class="p-grid">
            <div class="p-col-12" style="text-align: right">
              <Button label="View Report" />
            </div>
          </div>
        </div>
        <div class="p-formgrid p-grid">
          <div class="p-col-6 p-lg-6">
            <ul class="activity-list">
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">Assign Security</h5>
                  <div class="count" style="background-color:#f9c851">
                    <i class="pi pi-key" style="fontSize: 2rem"></i>
                  </div>
                </div>
              </li>
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">Assign Tenant</h5>
                  <div class="count" style="background-color:#007be5">
                    <i class="pi pi-user-plus" style="fontSize: 2rem"></i>
                  </div>
                </div>
              </li>
            </ul>
          </div>
          <div class="p-col-6 p-lg-6">
            <ul class="activity-list">
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">Make Payment</h5>
                  <div class="count" style="background-color:#20d077">
                    <i class="pi pi-id-card" style="fontSize: 2rem"></i>
                  </div>
                </div>
              </li>
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
                  <h5 class="activity p-m-0">Add Apartment</h5>
                  <div class="count" style="background-color:#ef6262">
                    <i class="pi pi-id-card" style="fontSize: 2rem"></i>
                  </div>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </Panel>
    </div>
    <div class="p-col-12 p-lg-4">
      <Panel header="Activity" style="height: 100%">
        <div class="activity-header">
          <div class="p-grid">
            <div class="p-col-12" style="text-align: right">
              <Button label="Refresh" icon="pi pi-refresh" />
            </div>
          </div>
        </div>
        <ul class="activity-list">
          <li>
            <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
              <h5 class="activity p-m-0">Income</h5>
              <div class="count">LKR 19034</div>
            </div>
          </li>
          <li>
            <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
              <h5 class="activity p-m-0">Profit</h5>
              <div class="count">LKR 1903</div>
            </div>
          </li>
        </ul>
      </Panel>
    </div>
  </div>
</template>

<script>


export default {
  data() {
    return {
      tasksCheckbox: [],
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
  productService: null,
  eventService: null,

  mounted() {
    this.productService
      .getProductsSmall()
      .then((data) => (this.products = data));
    this.eventService.getEvents().then((data) => (this.events = data));

    let afId = this.$route.query["af_id"];
    if (afId) {
      let today = new Date();
      let expire = new Date();
      expire.setTime(today.getTime() + 3600000 * 24 * 7);
      document.cookie =
        "primeaffiliateid=" +
        afId +
        ";expires=" +
        expire.toUTCString() +
        ";path=/; domain:primefaces.org";
    }
  },
  methods: {
    formatCurrency(value) {
      return value.toLocaleString("en-US", {
        style: "currency",
        currency: "USD",
      });
    },
  },
};
</script>

<style lang="scss" scoped>
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
