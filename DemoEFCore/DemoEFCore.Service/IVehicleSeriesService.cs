using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEFCore.Service
{
    public interface IVehicleSeriesService
    {
        Task<WebApiResult<bool>> DeleteAsync(Guid Id);
        Task<WebApiResult<IEnumerable<VehicleSeriesDto>>> GetAllAsync(string filter,int pageIndex, int pageSize, string sortExpression);
        Task<WebApiResult<VehicleSeries>> GetByIdAsync(Guid Id);
        Task<WebApiResult<bool>> SaveAsync(VehicleSeries model);
        Task<bool> ValidNameAsync(VehicleSeries model);
    }
}