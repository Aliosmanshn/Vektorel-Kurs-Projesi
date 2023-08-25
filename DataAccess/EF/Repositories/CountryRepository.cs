using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class CountryRepository : BaseRepository<Country, GeziContext>, ICountryRepository
    {
      

        public async Task<Country> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Id == Id);
            return result;
        }
    }
}
