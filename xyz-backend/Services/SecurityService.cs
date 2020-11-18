using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Driver;

namespace  xyz_backend.Services
{
    public class SecurityService : ISecurityService
    {
        private IMongoCollection<Security> _securities;

        public SecurityService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _securities = database.GetCollection<Security>(settings.SecurityCollectionName);

        }
        public async Task<ServiceResponse<Security>> addUser(Security security)
        {
            ServiceResponse<Security> serviceResponse = new ServiceResponse<Security>();
            await _securities.InsertOneAsync(security);
            serviceResponse.Data = security;
            serviceResponse.Success = true;
            serviceResponse.Message = "New User Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAllUser()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _securities.Find(_ => true).ToListAsync();
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User";
            return serviceResponse;
        }
    }

    public interface ISecurityService
    {
        Task<ServiceResponse<Security>> addUser(Security security);
        Task<ServiceResponse<object>> getAllUser();
    }
}