using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class DistrictRepository : BaseRepository<District, GeziContext>, IDistrictRepository
    {
       

        public async Task<District> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Id == Id);
            return result;
        }
    }
}
