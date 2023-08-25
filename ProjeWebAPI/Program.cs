using Businness.Implementation;
using Businness.Interfaces;
using DataAccess.EF.Repositories;
using DataAccess.Interfaces;
using AddressBs = Businness.Implementation.AddressBs;

namespace ProjeWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IAddressBs, AddressBs>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();

            builder.Services.AddScoped<ICategoryBs, CategoryBs>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<ICityBs, CityBs>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();

            builder.Services.AddScoped<ICommentBs, CommentBs>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            builder.Services.AddScoped<ICountryBs, CountryBs>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();

            builder.Services.AddScoped< IDistrictBs, DistrictBs >();
            builder.Services.AddScoped< IDistrictRepository,  DistrictRepository > ();

            builder.Services.AddScoped<IExecutiveBs, ExecutiveBs>();
            builder.Services.AddScoped<IExecutiveRepository, ExecutiveRepository>();

            builder.Services.AddScoped<ITownBs, TownBs>();
            builder.Services.AddScoped<ITownRepository, TownRepository>();

            builder.Services.AddScoped<ITripBs, TripBs>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();

            builder.Services.AddScoped<IUserBs, UserBs>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}