﻿using CommonTypes.DataAccess.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country> GetByIDAsync(int Id, params string[] includeList);
    }
}
