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
import { Login } from "../service/LoginService";

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
          (x) => x.status == "Compeleted"
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
      // this.allOrder
      let tmpArray = [];

      for (let i = 0; i < this.allOrder.length; i++) {
        // console.log(this.allOrder[i].addToCard);
        tmpArray.push(...this.allOrder[i].addToCard);
      }

      console.log(tmpArray);

      let countArray = tmpArray.reduce(function (acc, val) {
        var o = acc
          .filter(function (obj) {
            return obj.name == val.name;
          })
          .pop() || { name: val.name, count: 0 };

        o.count += val.count;
        acc.push(o);
        return acc;
      }, []);

      let removedDuplicate = [...new Set([...countArray])];

      let exportObj = removedDuplicate.map((x) => {
        return {
          Name: x.name,
          Count: x.count,
        };
      });
      var headers = {
        Name: "Name",
        Count: "Count",

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
        convertToCSV(objArray) {
      var array = typeof objArray != "object" ? JSON.parse(objArray) : objArray;
      var str = "";

      for (var i = 0; i < array.length; i++) {
        var line = "";
        for (var index in array[i]) {
          if (line != "") line += ",";

          line += array[i][index];
        }

        str += line + "\r\n";
      }

      return str;
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
