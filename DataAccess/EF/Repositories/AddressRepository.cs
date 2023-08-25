﻿using CommonTypes.DataAccess.Implementdations.EF;
using DataAccess.EF.Context;
using DataAccess.Interfaces;
using Model.Entities;


namespace DataAccess.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address, GeziContext>, IAddressRepository
    {
        
        public async Task<Address> GetByIDAsync(int Id, params string[] includeList)
        {
            var result = await GetAsync(x => x.Id == Id);
            return result;
        }
    }
}
