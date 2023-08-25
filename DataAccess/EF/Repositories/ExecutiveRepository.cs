using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class ExecutiveRepository : BaseRepository<Executive, GeziContext>, IExecutiveRepository
    {
       

        public async Task<Executive> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Yoneticiid == Id);
            return result;
        }
    }
}
