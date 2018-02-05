using DemoEFCore.BaseRepository;
using DemoEFCore.Models;
using System.Threading.Tasks;

namespace DemoEFCore.Repository
{
    public class VehicleSeriesRepository : BaseRepository<VehicleSeries>, IVehicleSeriesRepository
    {
        public VehicleSeriesRepository(CommonContext context)
            : base(context)
        { }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(VehicleSeries entity)
        {
            try
            {
                var series = GetSingle(entity.Id);

                if (series == null)
                    return await AddAsync(entity);

                series.SeriesName = entity.SeriesName;
                return await UpdateAsync(series);
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
        public bool Save(VehicleSeries entity)
        {
            try
            {
                var series = GetSingle(x => x.Id == entity.Id);

                if (series == null)
                    Add(entity);
                else
                {
                    series.SeriesName = entity.SeriesName;
                    Update(series);
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
