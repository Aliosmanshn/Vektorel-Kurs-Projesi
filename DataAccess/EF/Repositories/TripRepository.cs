using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class TripRepository : BaseRepository<Trip, GeziContext>, ITripRepository
    {
       

        public async Task<Trip> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.TripId == Id);
            return result;
        }
    }
}
