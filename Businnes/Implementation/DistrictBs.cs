using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.DistrictDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class DistrictBs : IDistrictBs

    {
        private readonly IDistrictRepository _districtRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public DistrictBs(IMapper mapper , IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var district = await _districtRepository.GetByIDAsync(id);

            await _districtRepository.DeleteAsync(district);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<DistrictGetDto>>> GetAsync(params string[] includeList)
        {
            var district = await _districtRepository.GetAllAsync(includeList: includeList);
            if (district.Count > 0)
            {
                var districtList = _mapper.Map<List<DistrictGetDto>>(district);
                var response = ApiResponse<List<DistrictGetDto>>.Success(StatusCodes.Status200OK, districtList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<DistrictGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var district = await _districtRepository.GetByIDAsync(Id , includeList);

            if (district != null)
            {
                var dto = _mapper.Map<DistrictGetDto>(district);
                return ApiResponse<DistrictGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<District>> InsertAsync(DistrictPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var district = _mapper.Map<District>(entity);
            var insertedDistrict = await _districtRepository.InsertAsync(district);
            return ApiResponse<District>.Success(StatusCodes.Status200OK, insertedDistrict);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DistrictPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var district = _mapper.Map<District>(entity);
            await _districtRepository.UpdateAsync(district);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
