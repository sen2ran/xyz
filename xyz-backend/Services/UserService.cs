using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using xyz_backend.Models;

namespace  xyz_backend.Services
{
    public class UserService : IUserService
    {
        private IMongoCollection<User> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);

        }
        public async Task<ServiceResponse<User>> addUser(User newUser)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.password);
            newUser.password = passwordHash;
            await _users.InsertOneAsync(newUser);
            serviceResponse.Data = newUser;
            serviceResponse.Success = true;
            serviceResponse.Message = "New User Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> deleteUser(string id)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var documents = await _users.DeleteOneAsync(user => user.id == id);
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
            // var documents = await _users.Find(_ => true).ToListAsync();
            var documents = await _users.Find(_ => true).Project(Builders<User>.Projection.Exclude("password")).ToListAsync();
            var dotNetObjList = documents.ConvertAll(BsonTypeMapper.MapToDotNetValue);
            serviceResponse.Data = dotNetObjList;
            serviceResponse.Success = true;
            serviceResponse.Message = "All User ";
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> login(LoginUser loginUser)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var user = await _users.Find<User>(user => user.email == loginUser.email).SingleOrDefaultAsync();
            if (user != null)
            {
                if (user.isApproved)
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
                    serviceResponse.Message = "User have to be approved";
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

        public async Task<ServiceResponse<User>> updateUser(ApprovalUser tmpUser)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();

            var documents = await _users.Find<User>(user => user.id == tmpUser.id).FirstOrDefaultAsync();

            Console.WriteLine(documents);

            documents.isApproved = tmpUser.isApproved;

            await _users.ReplaceOneAsync(user => user.id == tmpUser.id, documents);
            serviceResponse.Data = documents;
            serviceResponse.Success = true;
            serviceResponse.Message = "User Updated Successfully";
            return serviceResponse;
        }
    }

    public interface IUserService
    {
        Task<ServiceResponse<User>> addUser(User newUser);
        Task<ServiceResponse<object>> login(LoginUser loginUser);
        Task<ServiceResponse<object>> getAllUser();
        Task<ServiceResponse<object>> deleteUser(string id);
        Task<ServiceResponse<User>> updateUser(ApprovalUser tmpUser);

    }
}