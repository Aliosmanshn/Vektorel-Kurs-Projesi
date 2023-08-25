using CommonTypes.Utilities;
using Model.Dtos.DistrictDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface IDistrictBs
    {
        Task<ApiResponse<List<DistrictGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<DistrictGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<District>> InsertAsync(DistrictPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(DistrictPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

