using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.TownDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class TownBs : ITownBs

    {
        private readonly ITownRepository _townRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public TownBs(IMapper mapper , ITownRepository townRepository)
        {
            _townRepository = townRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var town = await _townRepository.GetByIDAsync(id);

            await _townRepository.DeleteAsync(town);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<TownGetDto>>> GetAsync(params string[] includeList)
        {
            var town = await _townRepository.GetAllAsync(includeList: includeList);
            if (town.Count > 0)
            {
                var townList = _mapper.Map<List<TownGetDto>>(town);
                var response = ApiResponse<List<TownGetDto>>.Success(StatusCodes.Status200OK, townList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<TownGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var town = await _townRepository.GetByIDAsync(Id , includeList);

            if (town != null)
            {
                var dto = _mapper.Map<TownGetDto>(town);
                return ApiResponse<TownGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Town>> InsertAsync(TownPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var town = _mapper.Map<Town>(entity);
            var insertedTown = await _townRepository.InsertAsync(town);
            return ApiResponse<Town>.Success(StatusCodes.Status200OK, insertedTown);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(TownPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var town = _mapper.Map<Town>(entity);
            await _townRepository.UpdateAsync(town);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
