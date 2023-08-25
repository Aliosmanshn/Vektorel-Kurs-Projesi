using CommonTypes.Utilities;
using Model.Dtos.CountryDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ICountryBs
    {
        Task<ApiResponse<List<CountryGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<CountryGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Country>> InsertAsync(CountryPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

