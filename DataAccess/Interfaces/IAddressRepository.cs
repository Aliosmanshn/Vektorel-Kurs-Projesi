using CommonTypes.DataAccess.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    
    public interface IAddressRepository : IBaseRepository<Address>
    {
        //eksta işler yapılacak
        Task<Address> GetByIDAsync(int Id,params string[] includeList);
        

    }
}
