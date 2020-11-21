using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Driver;

namespace xyz_backend.Services
{
    public class OrderService : IOrder
    {
        private IMongoCollection<Order> _orders;
        public OrderService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
        }
        public async Task<ServiceResponse<Order>> makeOrder(Order newOrder)
        {
            ServiceResponse<Order> serviceResponse = new ServiceResponse<Order>();
            await _orders.InsertOneAsync(newOrder);
            serviceResponse.Data = newOrder;
            serviceResponse.Success = true;
            serviceResponse.Message = "New Order Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAll()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _orders.Find(_ => true).ToListAsync();
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "All Orders";
            return serviceResponse;
        }
        public async Task<ServiceResponse<object>> getAllUserById(string id)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var orders = await _orders.Find(x => x.userId == id).ToListAsync();
            serviceResponse.Data = orders;
            serviceResponse.Success = true;
            serviceResponse.Message = "Get All Order By User";
            return serviceResponse;
        }
    }

    public interface IOrder
    {
        Task<ServiceResponse<Order>> makeOrder(Order dressType);
        Task<ServiceResponse<object>> getAll();
        Task<ServiceResponse<object>> getAllUserById(string id);
    }
}

