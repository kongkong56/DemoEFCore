using DemoEFCore.BaseRepository;
using System;

namespace DemoEFCore.Models
{
    /// <summary>
    /// 车型类
    /// </summary>
    public class Vehicle : BaseEntity
    {   /// <summary>
        /// 车型名称
        /// </summary>
        public string VehicleName { get; set; }
        /// <summary>
        /// 车型年份
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 生产厂商
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 车系ID
        /// </summary>
        public Guid SeriesId { get; set; }
        public bool isOnly { get; set; }
        public virtual VehicleSeries VehicleSeries { get; set; }
    }
}
