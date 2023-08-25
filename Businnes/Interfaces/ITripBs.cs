using CommonTypes.Utilities;
using Model.Dtos.TripDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ITripBs
    {
        Task<ApiResponse<List<TripGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<TripGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Trip>> InsertAsync(TripPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(TripPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

