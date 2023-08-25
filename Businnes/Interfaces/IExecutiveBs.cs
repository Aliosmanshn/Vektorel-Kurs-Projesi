using CommonTypes.Utilities;
using Model.Dtos.ExecutiveDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface IExecutiveBs
    {
        Task<ApiResponse<List<ExecutiveGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<ExecutiveGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Executive>> InsertAsync(ExecutivePostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(ExecutivePutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

