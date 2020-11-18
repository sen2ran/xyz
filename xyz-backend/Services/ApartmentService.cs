using System;
using System.Dynamic;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace  xyz_backend.Services
{
    public class ApartmentService : IApartmentService
    {
        private IMongoCollection<Apartment> _apartment;
        private IMongoCollection<Unit> _unit;

        public ApartmentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _apartment = database.GetCollection<Apartment>(settings.ApartmentCollectionName);
            _unit = database.GetCollection<Unit>(settings.UnitCollectionName);
        }
        public async Task<ServiceResponse<Apartment>> addApartment(ReqApartment newaApartment)
        {

            ServiceResponse<Apartment> serviceResponse = new ServiceResponse<Apartment>();

            Apartment apartment = new Apartment()
            {
                security = newaApartment.security,
                maintenancePerUnitDefaultPrice = newaApartment.maintenancePerUnitDefaultPrice,
                apartmentName = newaApartment.apartmentName,
                apartmentId = newaApartment.apartmentId,
                noOfUnit = newaApartment.noOfUnit,
                address = newaApartment.address,
                cityName = newaApartment.cityName,
            };

            // apartment.latAndLon = new GeoJson2DCoordinates(newaApartment.lat, newaApartment.lon);

            await _apartment.InsertOneAsync(apartment);
            serviceResponse.Data = apartment;
            serviceResponse.Success = true;
            serviceResponse.Message = "New Apartment Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> addUnitById(string id, Unit payload)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            // var allUnit = await _unit.Find(x => x.apartmentId == id).ToListAsync();
            // var apartment = await _apartment.Find(x => x.id == id).SingleOrDefaultAsync();
            await _unit.InsertOneAsync(payload);

            // dynamic document = new ExpandoObject();
            // document.allUnit = allUnit;
            // document.apartmentDetails = apartment;

            serviceResponse.Data = payload;
            serviceResponse.Success = true;
            serviceResponse.Message = "Testing";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAll()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _apartment.Find(_ => true).ToListAsync();
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> getAllUnitById(string id)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var allUnit = await _unit.Find(x => x.apartmentId == id).ToListAsync();
            var apartment = await _apartment.Find(x => x.id == id).SingleOrDefaultAsync();

            dynamic document = new ExpandoObject();
            document.allUnit = allUnit;
            document.apartmentDetails = apartment;

            serviceResponse.Data = document;
            serviceResponse.Success = true;
            serviceResponse.Message = "Testing";
            return serviceResponse;
        }
    }
    public interface IApartmentService
    {
        Task<ServiceResponse<Apartment>> addApartment(ReqApartment apartment);
        Task<ServiceResponse<object>> getAll();
        Task<ServiceResponse<object>> getAllUnitById(string id);
        Task<ServiceResponse<object>> addUnitById(string id, Unit payload);
    }
}