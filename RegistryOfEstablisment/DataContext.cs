using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=RegistryOfEstablishment; User Id = postgres; password = faerdas1237ert");
        }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<ManagementTerritory> ManagementTerritories { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users {get;set;}
        
    }

}
