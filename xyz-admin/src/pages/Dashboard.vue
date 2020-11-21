 <template>
  <div class="p-grid p-fluid dashboard">
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #007be5; color: #00448f">
          <span>T</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>Total Order </span>
          <span class="count">{{ count }}</span>
        </div>
      </div>
    </div>
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #ef6262; color: #a83d3b">
          <span>P</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>Pending Order</span>
          <span class="count">{{ pending }}</span>
        </div>
      </div>
    </div>
    <div class="p-col-12 p-md-6 p-xl-4">
      <div class="highlight-box">
        <div class="initials" style="background-color: #20d077; color: #038d4a">
          <span>2</span>
        </div>
        <div class="highlight-details">
          <i class="pi pi-check"></i>
          <span>Compeleted</span>
          <span class="count">{{ completed }}</span>
        </div>
      </div>
    </div>

    <div class="p-col-12 p-lg-8">
      <Panel header="Navigation" style="height: 100%">
        <div class="activity-header">
          <div class="p-grid">
            <div class="p-col-12" style="text-align: right">
              <Button @click="downloadReport()" label="Download  dress count" />
            </div>
          </div>
        </div>
        <div class="p-formgrid p-grid">
          <div class="p-col-6 p-lg-6">
            <ul class="activity-list">
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">Orders</h5>
                  <div class="count" style="background-color: #f9c851">
                    <i class="pi pi-money-bill" style="fontsize: 2rem"></i>
                  </div>
                </div>
              </li>
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">Dress Type</h5>
                  <div class="count" style="background-color: #007be5">
                    <i class="pi pi-globe" style="fontsize: 2rem"></i>
                  </div>
                </div>
              </li>
            </ul>
          </div>
          <div class="p-col-6 p-lg-6">
            <ul class="activity-list">
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3 p-link">
                  <h5 class="activity p-m-0">User</h5>
                  <div class="count" style="background-color: #20d077">
                    <i class="pi pi-user-plus" style="fontsize: 2rem"></i>
                  </div>
                </div>
              </li>
              <li>
                <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
                  <h5 class="activity p-m-0">Admin</h5>
                  <div class="count" style="background-color: #ef6262">
                    <i class="pi pi-users" style="fontsize: 2rem"></i>
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
              <Button label="Refresh" icon="pi pi-refresh" @click="initFn()" />
            </div>
          </div>
        </div>
        <ul class="activity-list">
          <li>
            <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
              <h5 class="activity p-m-0">Income</h5>
              <div class="count">LKR {{ price[0].total }}</div>
            </div>
          </li>
          <li>
            <div class="p-d-flex p-jc-between p-ai-center p-mb-3">
              <h5 class="activity p-m-0">Profit</h5>
              <div class="count">LKR {{ price[0].total * 0.1 }}</div>
            </div>
          </li>
        </ul>
      </Panel>
    </div>
  </div>
</template>

<script>
import { GetAllOrders } from "../service/DressService";


export default {
  data() {
    return {
      allOrder: [],
      count: 0,
      pending: 0,
      completed: 0,
      price: [
        {
          total: 0,
        },
      ],
    };
  },
  productService: null,
  eventService: null,

  mounted() {
    this.initFn();
  },
  methods: {
    async initFn() {
      try {
        let { data } = await GetAllOrders();
        console.log(data);
        this.allOrder = data.data;
        this.count = data.data.length;
        this.completed = data.data.filter(
          (x) => x.status == "Completed"
        ).length;
        this.pending = data.data.length - this.completed;

        this.price = data.data.reduce(function (acc, val) {
          var o = acc
            .filter(function (obj) {
              return obj.name == val.name;
            })
            .pop() || { name: val.name, total: 0 };

          o.total += val.total;
          acc.push(o);
          return acc;
        }, []);
      } catch (error) {
        this.$toast.add({
          severity: "error",
          summary: "Error",
          detail: error,
          life: 3000,
        });
      }
    },
    downloadReport() {
      let exportObj = this.allOrder.map((x) => {
        return {
          OrderID: x.orderID.id,
          Date: x.orderID.date,
          StoreName: x.vendorDetails.storeName,
          StoreLocation: x.vendorDetails.businessName.replace(/,/g, ""),
          StorePhone: x.vendorDetails.phone,
          CutomerName: x.customerDetails.fullName,
          CustomerPhone: x.customerDetails.contactInfo,
          DeliveryLocation: x.deliveryDetails.deliveryAddress.replace(/,/g, ""),
          DeliveryCharge: x.deliveryDetails.deliverCharge,
          OrderItems: x.orderDetails.items.length,
          OrderTotal: x.paymentDetails.total,
          OrderStatus: x.orderStatus,
          PaymentType: x.paymentDetails.paymentMethod,
        };
      });
      var headers = {
        OrderID: "Order Id",
        Date: "Date",
        StoreName: "Store Name",
        StoreLocation: "Store Location",
        StorePhone: "Store Phone Number",
        CutomerName: "Customer Name",
        CustomerPhone: "Customer Phone Number",
        DeliveryLocation: "Delivery Location",
        DeliveryCharge: "Delivery Charge",
        OrderItems: "Order Items",
        OrderTotal: "Order Total",
        OrderStatus: "Order Status",
        PaymentType: "Payment Type",
      };
      var fileTitle = "Dress Count"; // or 'my-unique-title'

      this.exportCSVFile(headers, exportObj, fileTitle);
    },

    exportCSVFile(headers, items, fileTitle) {
      if (headers) {
        items.unshift(headers);
      }

      // Convert Object to JSON
      var jsonObject = JSON.stringify(items);

      var csv = this.convertToCSV(jsonObject);

      var exportedFilenmae = fileTitle + ".csv" || "export.csv";

      var blob = new Blob([csv], { type: "text/csv;charset=utf-8;" });
      if (navigator.msSaveBlob) {
        // IE 10+
        navigator.msSaveBlob(blob, exportedFilenmae);
      } else {
        var link = document.createElement("a");
        if (link.download !== undefined) {
          // feature detection
          // Browsers that support HTML5 download attribute
          var url = URL.createObjectURL(blob);
          link.setAttribute("href", url);
          link.setAttribute("download", exportedFilenmae);
          link.style.visibility = "hidden";
          document.body.appendChild(link);
          link.click();
          document.body.removeChild(link);
        }
      }
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
