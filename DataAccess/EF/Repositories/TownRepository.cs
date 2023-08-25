using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class TownRepository : BaseRepository<Town, GeziContext>, ITownRepository
    {
      

        public async Task<Town> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.TownsId == Id);
            return result;
        }
    }
}
