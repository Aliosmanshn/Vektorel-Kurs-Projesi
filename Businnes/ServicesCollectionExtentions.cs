﻿using DataAccess.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness
{
    public static class ServicesCollectionExtentions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            //services.AddScoped<IProductBs, ProductBs>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            //services.AddScoped<IMessageBs, MessageBs>();
            //services.AddScoped<IMessageRepository, MessageRepository>();

            //services.AddScoped<IProductImageBs, ProductImageBs>();
            //services.AddScoped<IProductImageRepository, ProductImageRepository>();

            //services.AddScoped<IAdminLoginBs, AdminLoginBs>();
            //services.AddScoped<IAdminLoginRepository, AdminLoginRepository>();

            //services.AddScoped<ICategoryBs, CategoryBs>();
            //services.AddScoped<ICategoryRespository, CategoryRepository>();

            //services.AddScoped<ICompanyInfoBs, CompanyInfoBs>();
            //services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();


            //services.AddAutoMapper(typeof(ProductMapperProfile).Assembly);//aynı zamanda DI yapmamızı sağlıyor

        }
    }
}
