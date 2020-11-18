using System;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace  xyz_backend.Services
{
    public class AdminService : IAdminService
    {
        private IMongoCollection<Admin> _admins;

        public AdminService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _admins = database.GetCollection<Admin>(settings.AdminCollectionName);

        }
        public async Task<ServiceResponse<Admin>> addUser(Admin newUser)
        {
            ServiceResponse<Admin> serviceResponse = new ServiceResponse<Admin>();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.password);
            newUser.password = passwordHash;
            await _admins.InsertOneAsync(newUser);
            serviceResponse.Data = newUser;
            serviceResponse.Success = true;
            serviceResponse.Message = "New User Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> deleteUser(string id)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _admins.DeleteOneAsync(user => user.id == id);
            if (documents.DeletedCount == 1)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = true;
                serviceResponse.Message = "User Deleted";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User Not Found";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<object>> getAllUser()
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _admins.Find(_ => true).Project(Builders<Admin>.Projection.Exclude("password")).ToListAsync();
            var dotNetObjList = documents.ConvertAll(BsonTypeMapper.MapToDotNetValue);
            serviceResponse.Data = dotNetObjList;
            serviceResponse.Success = true;
            serviceResponse.Message = "All Admin ";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> login(LoginUser loginUser)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var user = await _admins.Find<Admin>(user => user.email == loginUser.email).SingleOrDefaultAsync();
            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(loginUser.password, user.password);
                if (verified)
                {
                    user.password = null;
                    serviceResponse.Data = user;
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Login Succesfully";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Data = "";
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Email or Password wrong";
                    return serviceResponse;
                }
            }
            else
            {
                serviceResponse.Data = "";
                serviceResponse.Success = false;
                serviceResponse.Message = "Email or Password wrong";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Admin>> updateUser(Admin tmpUser)
        {
            ServiceResponse<Admin> serviceResponse = new ServiceResponse<Admin>();

            var documents = await _admins.Find<Admin>(user => user.id == tmpUser.id).FirstOrDefaultAsync();

            documents.name = tmpUser.name;

            if (tmpUser.password != null)
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(tmpUser.password);
                documents.password = passwordHash;
            }
            await _admins.ReplaceOneAsync(user => user.id == tmpUser.id, documents);
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "User Updated Successfully";
            return serviceResponse;
        }
    }

    public interface IAdminService
    {
        Task<ServiceResponse<Admin>> addUser(Admin newUser);
        Task<ServiceResponse<object>> login(LoginUser loginUser);
        Task<ServiceResponse<object>> getAllUser();
        Task<ServiceResponse<object>> deleteUser(string id);
        Task<ServiceResponse<Admin>> updateUser(Admin tmpUser);

    }
}