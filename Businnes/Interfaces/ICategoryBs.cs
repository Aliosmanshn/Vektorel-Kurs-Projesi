using CommonTypes.Utilities;
using Model.Dtos.CategoryDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<CategoryGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Categories>> InsertAsync(CategoryPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

