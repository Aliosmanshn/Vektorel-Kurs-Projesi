using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.CountryDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class CountryBs : ICountryBs

    {
        private readonly ICountryRepository _countryRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public CountryBs(IMapper mapper , ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var country = await _countryRepository.GetByIDAsync(id);

            await _countryRepository.DeleteAsync(country);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CountryGetDto>>> GetAsync(params string[] includeList)
        {
            var country = await _countryRepository.GetAllAsync(includeList: includeList);
            if (country.Count > 0)
            {
                var countryList = _mapper.Map<List<CountryGetDto>>(country);
                var response = ApiResponse<List<CountryGetDto>>.Success(StatusCodes.Status200OK, countryList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<CountryGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var country = await _countryRepository.GetByIDAsync(Id , includeList);

            if (country != null)
            {
                var dto = _mapper.Map<CountryGetDto>(country);
                return ApiResponse<CountryGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Country>> InsertAsync(CountryPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var country = _mapper.Map<Country>(entity);
            var insertedCountry = await _countryRepository.InsertAsync(country);
            return ApiResponse<Country>.Success(StatusCodes.Status200OK, insertedCountry);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var country = _mapper.Map<Country>(entity);
            await _countryRepository.UpdateAsync(country);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
