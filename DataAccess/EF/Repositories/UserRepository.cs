using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class UserRepository : BaseRepository<User, GeziContext>, IUserRepository
    {
        

        public async Task<User> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.UserId == Id);
            return result;
        }
    }
}
