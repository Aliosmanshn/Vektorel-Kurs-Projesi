using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.CityDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class CityBs : ICityBs

    {
        private readonly ICityRepository _cityRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public CityBs(IMapper mapper , ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var city = await _cityRepository.GetByIDAsync(id);

            await _cityRepository.DeleteAsync(city);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CityGetDto>>> GetAsync(params string[] includeList)
        {
            var city = await _cityRepository.GetAllAsync(includeList: includeList);
            if (city.Count > 0)
            {
                var cityList = _mapper.Map<List<CityGetDto>>(city);
                var response = ApiResponse<List<CityGetDto>>.Success(StatusCodes.Status200OK, cityList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<CityGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var city = await _cityRepository.GetByIDAsync(Id , includeList);

            if (city != null)
            {
                var dto = _mapper.Map<CityGetDto>(city);
                return ApiResponse<CityGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<City>> InsertAsync(CityPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var city = _mapper.Map<City>(entity);
            var insertedCity = await _cityRepository.InsertAsync(city);
            return ApiResponse<City>.Success(StatusCodes.Status200OK, insertedCity);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CityPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var city = _mapper.Map<City>(entity);
            await _cityRepository.UpdateAsync(city);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
