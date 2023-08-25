using CommonTypes.Utilities;
using Model.Dtos.AddressDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface IAddressBs
    {
        Task<ApiResponse<List<AddressGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<AddressGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Address>> InsertAsync(AddressPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(AddressPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

