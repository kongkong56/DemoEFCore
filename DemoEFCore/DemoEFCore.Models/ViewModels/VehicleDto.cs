using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Models.ViewModels
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        /// <summary>
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
        public Guid SeriesId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
