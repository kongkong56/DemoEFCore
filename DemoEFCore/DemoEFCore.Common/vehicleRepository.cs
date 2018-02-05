using DemoEFCore.BaseRepository;
using DemoEFCore.Models;
using System.Threading.Tasks;

namespace DemoEFCore.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CommonContext context)
            : base(context)
        { }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(Vehicle model)
        {
            try
            {
                var vehicle = GetSingle(model.Id);

                if (vehicle == null)
                    return await AddAsync(model);
                else
                {
                    vehicle.VehicleName = model.VehicleName;
                    vehicle.Manufacturer = model.Manufacturer;
                    vehicle.Price = model.Price;
                    vehicle.SeriesId = model.SeriesId;
                    vehicle.Year = model.Year;
                    return await UpdateAsync(vehicle);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(Vehicle model)
        {
            try
            {
                var vehicle = GetSingle(x => x.Id == model.Id);

                if (vehicle == null)
                    Add(model);
                else
                {
                    vehicle.VehicleName = model.VehicleName;
                    vehicle.Manufacturer = model.Manufacturer;
                    vehicle.Price = model.Price;
                    vehicle.SeriesId = model.SeriesId;
                    vehicle.Year = model.Year;
                    Update(vehicle);
                }

                return Commit() >= 1;
            }
            catch
            {
                return false;
            }
        }

    }
}
