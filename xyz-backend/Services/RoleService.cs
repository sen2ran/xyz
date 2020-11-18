using System.Collections.Generic;
using System.Threading.Tasks;
using xyz_backend.Models;
using MongoDB.Driver;

namespace  xyz_backend.Services
{
    public class RoleService : IRoleService
    {
        private IMongoCollection<Role> _roles;
        public RoleService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _roles = database.GetCollection<Role>(settings.RoleCollectionName);
        }
        //Add New Role
        public async Task<ServiceResponse<Role>> addRole(Role newRole)
        {
            ServiceResponse<Role> serviceResponse = new ServiceResponse<Role>();
            await _roles.InsertOneAsync(newRole);
            serviceResponse.Data = newRole;
            serviceResponse.Success = true;
            serviceResponse.Message = "Role Created Successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Role>>> getAllRole()
        {
            ServiceResponse<List<Role>> serviceResponse = new ServiceResponse<List<Role>>();
            List<Role> roles = (await _roles.FindAsync(book => true)).ToList();
            serviceResponse.Data = roles;
            serviceResponse.Success = true;
            serviceResponse.Message = "Get All Roles";
            return serviceResponse;
        }
    }

    public interface IRoleService
    {
        Task<ServiceResponse<Role>> addRole(Role newRole);
        Task<ServiceResponse<List<Role>>> getAllRole();
    }
}