using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;

namespace DataAccess.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Categories, GeziContext>, ICategoryRepository
    {
       

        public async Task<Categories> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Kategoriid == Id);
            return result;
        }
    }
}
