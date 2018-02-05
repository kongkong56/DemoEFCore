using DemoEFCore.BaseRepository;
using DemoEFCore.Models;
using System.Threading.Tasks;
namespace DemoEFCore.Repository
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        bool Save(Vehicle model);
        Task<bool> SaveAsync(Vehicle model);
    }
}