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
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<WebApiResult<IEnumerable<VehicleDto>>> GetAllVehiclesAsync(string serisId, int? pageIndex, int? pageSize, string sortExpression)
        {
            var startTime = DateTime.Now;

            var result = await _vehicleService.GetAllAsync(serisId, pageIndex ?? 1, pageSize ?? 10, sortExpression);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpGet("{Id}")]
        public async Task<WebApiResult<VehicleDto>> GetVehicleByIdAsync(Guid Id)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleService.GetByIdAsync(Id);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpPost]
        public async Task<WebApiResult<bool>> AddAsync([FromBody]Vehicle model)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleService.SaveAsync(model);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpPut("{Id}")]
        public async Task<WebApiResult<bool>> UpdateAsync([FromRoute] Guid Id, [FromBody]Vehicle model)
        {
            var result = new WebApiResult<bool>();
            var startTime = DateTime.Now;
            if (Id != model.Id)
            {
                result.Success = false;
                result.ErrorMessage = "Id参数有误";
            }
            else
                result = await _vehicleService.SaveAsync(model);

            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }
        [HttpDelete("{Id}")]
        public async Task<WebApiResult<bool>> DeleteAsync(Guid Id)
        {
            var startTime = DateTime.Now;
            var result = await _vehicleService.DeleteAsync(Id);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            return result;
        }

    }
}