using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.EF.Context
{
    public class GeziContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\; database=CorumGezi;User Id =sa;Password=Ali123456.; TrustServerCertificate=True");
                    }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Categories> Categories { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<Executive> Executives { get; set; }

        

      

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Trip> Trips { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}

