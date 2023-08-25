using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.ExecutiveDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class ExecutiveBs : IExecutiveBs

    {
        private readonly IExecutiveRepository _executiveRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public ExecutiveBs(IMapper mapper , IExecutiveRepository executiveRepository)
        {
            _executiveRepository = executiveRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var executive = await _executiveRepository.GetByIDAsync(id);

            await _executiveRepository.DeleteAsync(executive);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<ExecutiveGetDto>>> GetAsync(params string[] includeList)
        {
            var executive = await _executiveRepository.GetAllAsync(includeList: includeList);
            if (executive.Count > 0)
            {
                var executiveList = _mapper.Map<List<ExecutiveGetDto>>(executive);
                var response = ApiResponse<List<ExecutiveGetDto>>.Success(StatusCodes.Status200OK, executiveList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<ExecutiveGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var executive = await _executiveRepository.GetByIDAsync(Id , includeList);

            if (executive != null)
            {
                var dto = _mapper.Map<ExecutiveGetDto>(executive);
                return ApiResponse<ExecutiveGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Executive>> InsertAsync(ExecutivePostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var executive = _mapper.Map<Executive>(entity);
            var insertedExecutive = await _executiveRepository.InsertAsync(executive);
            return ApiResponse<Executive>.Success(StatusCodes.Status200OK, insertedExecutive);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ExecutivePutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var executive = _mapper.Map<Executive>(entity);
            await _executiveRepository.UpdateAsync(executive);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
