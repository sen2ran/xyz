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
    }

    public interface IOrder
    {
        Task<ServiceResponse<Order>> makeOrder(Order dressType);
    }
}

