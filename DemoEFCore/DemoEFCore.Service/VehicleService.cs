using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;
using DemoEFCore.Repository;
using ReflectionIT.Mvc.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;

namespace DemoEFCore.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;

            _mapper = mapper;
        }
        #region async
        public async Task<WebApiResult<IEnumerable<VehicleDto>>> GetAllAsync(string filter, int pageIndex, int pageSize, string sortExpression)
        {
            string baseSortExpression = "VehicleName";
            var query = _vehicleRepository.GetAllAsIQuerable();
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(c => c.SeriesId == new Guid(filter));
            if (string.IsNullOrWhiteSpace(sortExpression))
                sortExpression = baseSortExpression;
            var result = new WebApiResult<IEnumerable<Vehicle>>()
            {
                Data = await PagingList.CreateAsync(query, pageSize, pageIndex, sortExpression, baseSortExpression)

            };
            return _mapper.Map<WebApiResult<IEnumerable<Vehicle>>, WebApiResult<IEnumerable<VehicleDto>>>(result);
        }

        public async Task<WebApiResult<VehicleDto>> GetByIdAsync(Guid Id)
        {
            var result = new WebApiResult<Vehicle>();
            if (Id == Guid.Empty)
            {
                result.ErrorMessage = string.Format("车型ID有误:{0}", Id);
                result.Success = false;
            }
            else
                result.Data = await _vehicleRepository.GetSingleAsync(Id);
            return _mapper.Map<WebApiResult<VehicleDto>>(result);
        }
        public async Task<WebApiResult<bool>> SaveAsync(Vehicle model)
        {
            var result = new WebApiResult<bool>();
            if (model == null)
            {
                result.ErrorMessage = "参数有误";
                result.Success = false;
                return result;
            }
            if (await ValidNameAsync(model))
            {
                result.ErrorMessage = string.Format("已存在此车型：{0}", model.VehicleName);
                result.Success = false;
                result.Data = false;
                return result;
            }
            result.Data = await _vehicleRepository.SaveAsync(model);
            return result;
        }
        public async Task<WebApiResult<bool>> DeleteAsync(Guid Id)
        {
            var result = new WebApiResult<bool>();
            if (Id == Guid.Empty)
            {
                result.ErrorMessage = string.Format("车型ID有误:{0}", Id);
                result.Success = false;
                return result;
            }
            var model = await _vehicleRepository.GetSingleAsync(Id);

            if (model == null)
            {
                result.ErrorMessage = string.Format("车型ID有误:{0}", Id);
                result.Success = false;
            }
            else
                result.Data = await _vehicleRepository.DeleteAsync(model);
            return result;
        }
        public async Task<bool> ValidNameAsync(Vehicle model)
        {
            if (model.Id == Guid.Empty)
                return await _vehicleRepository.CheckExistAsync(x => x.VehicleName == model.VehicleName && x.Deleted == false);
            return await _vehicleRepository.CheckExistAsync(x => x.VehicleName == model.VehicleName && x.Id != model.Id && x.Deleted == false);
        }
        #endregion
    }
}
