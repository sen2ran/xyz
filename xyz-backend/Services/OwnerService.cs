using System;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace  xyz_backend.Services
{
    public class OwnerService : IOwnerService
    {
        private IMongoCollection<Owner> _owner;

        public OwnerService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owner = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }
        public async Task<ServiceResponse<Owner>> addOwner(Owner owner)
        {
            ServiceResponse<Owner> serviceResponse = new ServiceResponse<Owner>();
            await _owner.InsertOneAsync(owner);
            serviceResponse.Data = owner;
            serviceResponse.Success = true;
            serviceResponse.Message = "New User Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAll()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _owner.Find(_ => true).ToListAsync();
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> GetOwnerByName(string nameString)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var filter = new BsonDocument { { "ownerName", new BsonDocument { { "$regex", nameString } } } };
            var result = await _owner.Aggregate().Match(filter).ToListAsync();
            serviceResponse.Data = result;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User";
            return serviceResponse;
        }
    }

    public interface IOwnerService
    {
        Task<ServiceResponse<Owner>> addOwner(Owner owner);
        Task<ServiceResponse<object>> getAll();
        Task<ServiceResponse<object>> GetOwnerByName(string nameString);
    }
}