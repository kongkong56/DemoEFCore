using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEFCore.Service
{
    public interface IVehicleService
    {
        Task<WebApiResult<bool>> DeleteAsync(Guid Id);
        Task<WebApiResult<IEnumerable<VehicleDto>>> GetAllAsync(string filter, int pageIndex, int pageSize, string sortExpression);
        Task<WebApiResult<VehicleDto>> GetByIdAsync(Guid Id);
        Task<WebApiResult<bool>> SaveAsync(Vehicle model);
        Task<bool> ValidNameAsync(Vehicle model);
    }
}