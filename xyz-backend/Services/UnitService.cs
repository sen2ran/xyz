using System.Threading.Tasks;
using xyz_backend.Models;

namespace  xyz_backend.Services
{
    public class UnitService : IUnitService
    {
        public Task<ServiceResponse<Unit>> addUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }
    }
    public interface IUnitService
    {
        Task<ServiceResponse<Unit>> addUnit(Unit unit);
    }
}