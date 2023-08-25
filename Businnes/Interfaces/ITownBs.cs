using CommonTypes.Utilities;
using Model.Dtos.TownDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ITownBs
    {
        Task<ApiResponse<List<TownGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<TownGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Town>> InsertAsync(TownPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(TownPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

