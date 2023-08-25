using AutoMapper;
using Businness.CustomExceptions;
using Businness.Interfaces;
using CommonTypes.Utilities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Model.Dtos.CategoryDto;
using Model.Entities;

namespace Businness.Implementation
{
    public class CategoryBs : ICategoryBs
     
    {
        private readonly ICategoryRepository _categoryRepository; //dışarıdan erisim yok
        private readonly IMapper _mapper;
        public CategoryBs(IMapper mapper , ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIDAsync(id);

            await _categoryRepository.DeleteAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetAsync(params string[] includeList)
        {
            var category = await _categoryRepository.GetAllAsync(includeList: includeList);
            if (category.Count > 0)
            {
                var categoryList = _mapper.Map<List<CategoryGetDto>>(category);
                var response = ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, categoryList);

                return response;
            }

            throw new NotFoundException("Adres bulunamadı");
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIDAsync(int Id, params string[] includeList)
        {
            var category = await _categoryRepository.GetByIDAsync(Id , includeList);

            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Categories>> InsertAsync(CategoryPostDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var category = _mapper.Map<Categories>(entity);
            var insertedCategory = await _categoryRepository.InsertAsync(category);
            return ApiResponse<Categories>.Success(StatusCodes.Status200OK, insertedCategory);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto entity)
        {
            if (entity == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var category = _mapper.Map<Categories>(entity);
            await _categoryRepository.UpdateAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
