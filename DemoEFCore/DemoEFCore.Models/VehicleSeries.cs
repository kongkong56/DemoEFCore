using DemoEFCore.BaseRepository;
using System.Collections.Generic;

namespace DemoEFCore.Models
{
    /// <summary>
    /// 车系类
    /// </summary>
    public class VehicleSeries : BaseEntity
    {
        /// <summary>
        /// 车系名称
        /// </summary>
        public string SeriesName { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public VehicleSeries()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
