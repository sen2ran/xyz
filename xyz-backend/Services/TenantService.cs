using System;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace  xyz_backend.Services
{
    public class TenantService : ITenantService
    {
        private IMongoCollection<Tenant> _tenant;

        public TenantService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tenant = database.GetCollection<Tenant>(settings.TenantCollectionName);

        }
        public async Task<ServiceResponse<Tenant>> addTenant(Tenant tenant)
        {
            ServiceResponse<Tenant> serviceResponse = new ServiceResponse<Tenant>();
            await _tenant.InsertOneAsync(tenant);
            serviceResponse.Data = tenant;
            serviceResponse.Success = true;
            serviceResponse.Message = "New tenant Created Successfully";
            return serviceResponse;
        }

        public Task<ServiceResponse<object>> getAll()
        {
            throw new NotImplementedException();
        }
    }

    public interface ITenantService
    {
        Task<ServiceResponse<Tenant>> addTenant(Tenant tenant);
        Task<ServiceResponse<object>> getAll();
    }
}