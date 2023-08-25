using CommonTypes.DataAccess.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Categories>
    {
        Task<Categories> GetByIDAsync(int Id, params string[] includeList);

    }
}
