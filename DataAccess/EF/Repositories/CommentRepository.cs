using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class CommentRepository : BaseRepository<Comment, GeziContext>, ICommentRepository
    {
       

        public async Task<Comment> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Yorumid == Id);
            return result;
        }
    }
}
