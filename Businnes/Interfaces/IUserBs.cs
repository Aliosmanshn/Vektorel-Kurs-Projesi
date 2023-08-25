using CommonTypes.Utilities;
using Model.Dtos.UserDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface IUserBs
    {
        Task<ApiResponse<List<UserGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<UserGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<User>> InsertAsync(UserPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(UserPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

