using DemoEFCore.BaseRepository;
using DemoEFCore.Models;
using System.Threading.Tasks;

namespace DemoEFCore.Repository
{
    public interface IVehicleSeriesRepository : IBaseRepository<VehicleSeries>
    {
        Task<bool> SaveAsync(VehicleSeries entity);
        bool Save(VehicleSeries entity);
    }
}