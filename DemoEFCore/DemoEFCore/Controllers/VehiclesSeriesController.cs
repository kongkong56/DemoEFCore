using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;
using DemoEFCore.Service;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DemoEFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/VehiclesSeries")]
    public class VehiclesSeriesController : Controller
    {
        private readonly IVehicleSeriesService _vehicleSeriesService;
        public VehiclesSeriesController(IVehicleSeriesService vehicleSeriesService)
        {
            _vehicleSeriesService = vehicleSeriesService;
        }

        [HttpGet]
        public async Task<WebApiResult<IEnumerable<VehicleSeriesDto>>> GetAllAsync(string filter, int? page, int? pagesize, string sortExpression)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleSeriesService.GetAllAsync(filter, page ?? 1, pagesize ?? 10, sortExpression);

            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpGet("{Id}")]
        public async Task<WebApiResult<VehicleSeries>> GetSeriesByIdAsync(Guid Id)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleSeriesService.GetByIdAsync(Id);

            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpPost]
        public async Task<WebApiResult<bool>> AddAsync([FromBody]VehicleSeries model)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleSeriesService.SaveAsync(model);

            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpPut("{Id}")]
        public async Task<WebApiResult<bool>> UpdateAsync([FromRoute]Guid Id, [FromBody]VehicleSeries model)
        {
            var result = new WebApiResult<bool>();
            var startTime = DateTime.Now;
            if (Id != model.Id)
            {
                result.Success = false;
                result.ErrorMessage = "Id参数有误";
            }

            else
                result = await _vehicleSeriesService.SaveAsync(model);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpDelete("{Id}")]
        public async Task<WebApiResult<bool>> DeleteAsync(Guid Id)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleSeriesService.DeleteAsync(Id);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
    }
}