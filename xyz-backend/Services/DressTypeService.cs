using System;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Driver;
namespace xyz_backend.Services
{
    public class DressTypeService : IDressType
    {


        private IMongoCollection<DressType> _dressType;

        public DressTypeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dressType = database.GetCollection<DressType>(settings.DressTypeCollectionName);

        }
        public async Task<ServiceResponse<DressType>> addDress(DressType dressType)
        {
            ServiceResponse<DressType> serviceResponse = new ServiceResponse<DressType>();
            await _dressType.InsertOneAsync(dressType);
            serviceResponse.Data = dressType;
            serviceResponse.Success = true;
            serviceResponse.Message = "New Dress Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAll()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _dressType.Find(_ => true).ToListAsync();
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User";
            return serviceResponse;
        }
    }


    public interface IDressType
    {
        Task<ServiceResponse<object>> getAll();
        Task<ServiceResponse<DressType>> addDress(DressType dressType);

    }


}