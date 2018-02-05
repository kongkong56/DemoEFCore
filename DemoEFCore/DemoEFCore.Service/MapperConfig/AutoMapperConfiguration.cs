using AutoMapper;
using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;

namespace DemoEFCore.Service.MapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleSeries, VehicleSeriesDto>();
        }
    }
}
