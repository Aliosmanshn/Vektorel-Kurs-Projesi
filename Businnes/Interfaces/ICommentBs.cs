using CommonTypes.Utilities;
using Model.Dtos.CommentDto;
using Model.Entities;

namespace Businness.Interfaces
{
    public interface ICommentBs
    {
        Task<ApiResponse<List<CommentGetDto>>> GetAsync(params string[] includeList);       
        Task<ApiResponse<CommentGetDto>> GetByIDAsync(int Id, params string[] includeList);
        Task<ApiResponse<Comment>> InsertAsync(CommentPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(CommentPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

