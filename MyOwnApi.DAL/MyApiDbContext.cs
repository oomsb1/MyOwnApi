using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using MyOwnApi.DAL.Configurations;
using MyOwnAPI.Domain.Entities;
using MyOwnAPI.Domain.Interfaces;

namespace MyOwnApi.DAL
{
    public class MyApiDbContext: DbContext, IReadDbContext
    {
        public virtual DbSet<Driver> Chauffeurs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Applies all classes that implement IEntityTypeConfiguration<TEntity>, so if i were to add another
            //configuration for another table, it's automatically added also 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChauffeurConfiguration).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfigurationRoot configuration = new ConfigurationBuilder()
                //Requires Microsoft.Extensions.Configuration.Json
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.Development.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 3);
            });
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warningAction =>
            {
                warningAction.Log(
                    CoreEventId.FirstWithoutOrderByAndFilterWarning,
                    CoreEventId.RowLimitingOperationWithoutOrderByWarning
                    );
            });
        }
    }
}