using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEFCore.Models.ViewModels
{
    public class VehicleSeriesDto
    {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
