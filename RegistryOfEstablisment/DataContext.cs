using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;

namespace RegistryOfEstablisment.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<ManagementTerritory> ManagementTerritories { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=RegistryOfEstablishment; User Id = postgres; password = faerdas1237ert");
        }

    }

}
