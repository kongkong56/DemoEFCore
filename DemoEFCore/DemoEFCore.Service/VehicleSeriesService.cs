using AutoMapper;
using DemoEFCore.Models;
using DemoEFCore.Models.ViewModels;
using DemoEFCore.Repository;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEFCore.Service
{
    public class VehicleSeriesService : IVehicleSeriesService
    {
        private readonly IVehicleSeriesRepository _vehicleSeriesRepository;
        private readonly IMapper _mapper;
        public VehicleSeriesService(IVehicleSeriesRepository vehicleSeriesRepository, IMapper mapper)
        {
            _vehicleSeriesRepository = vehicleSeriesRepository;
            _mapper = mapper;
        }

        public async Task<WebApiResult<IEnumerable<VehicleSeriesDto>>> GetAllAsync(string filter, int pageIndex, int pageSize, string sortExpression)
        {
            string baseSortExpression = "SeriesName";
            var query = _vehicleSeriesRepository.GetAllAsIQuerable();
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(c => c.SeriesName.Contains(filter));
            if (string.IsNullOrWhiteSpace(sortExpression))
                sortExpression = baseSortExpression;
            var result = new WebApiResult<IEnumerable<VehicleSeries>>()
            {
                Data = await PagingList.CreateAsync(query, pageSize, pageIndex, sortExpression, baseSortExpression)
            };
            return Mapper.Map<WebApiResult<IEnumerable<VehicleSeries>>, WebApiResult<IEnumerable<VehicleSeriesDto>>>(result);
        }
        public async Task<WebApiResult<VehicleSeries>> GetByIdAsync(Guid Id)
        {
            var result = new WebApiResult<VehicleSeries>();
            if (Id == Guid.Empty)
            {
                result.ErrorMessage = string.Format("车系ID有误:{0}", Id);
                result.Success = false;
                return result;
            }
            result.Data = await _vehicleSeriesRepository.GetSingleAsync(Id);
            return result;
        }
        public async Task<WebApiResult<bool>> SaveAsync(VehicleSeries model)
        {
            var result = new WebApiResult<bool>();
            if (await ValidNameAsync(model))
            {
                result.ErrorMessage = string.Format("已存在此车系：{0}", model.SeriesName);
                result.Success = false;
                result.Data = false;
                return result;
            }
            result.Data = await _vehicleSeriesRepository.SaveAsync(model);
            return result;
        }

        public async Task<WebApiResult<bool>> DeleteAsync(Guid Id)
        {
            var result = new WebApiResult<bool>();
            if (Id == Guid.Empty)
            {
                result.ErrorMessage = string.Format("车系ID有误:{0}", Id);
                result.Success = false;
                return result;
            }

            var model = await _vehicleSeriesRepository.GetSingleAsync(Id);
            if (model == null)
            {
                result.ErrorMessage = string.Format("车系ID有误:{0}", Id);
                result.Success = false;
            }
            else
                result.Data = await _vehicleSeriesRepository.DeleteAsync(model);
            return result;
        }

        public async Task<bool> ValidNameAsync(VehicleSeries model)
        {
            if (model.Id == Guid.Empty)
                return await _vehicleSeriesRepository.CheckExistAsync(x => x.SeriesName == model.SeriesName && x.Deleted == false);
            return await _vehicleSeriesRepository.CheckExistAsync(x => x.SeriesName == model.SeriesName && x.Id != model.Id && x.Deleted == false);
        }
    }
}
