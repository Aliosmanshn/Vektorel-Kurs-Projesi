using CommonTypes.Utilities;
using Model.Dtos.CityDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ICityBs
    {
        Task<ApiResponse<List<CityGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<CityGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<City>> InsertAsync(CityPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(CityPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

