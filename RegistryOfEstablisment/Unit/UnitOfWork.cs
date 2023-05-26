using RegistryOfEstablisment.Model;
using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Unit
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public EnterpriseRepository Enterprises { get; init; }
        public RegistrationRepository Registrations { get; init; }
        public UserRepository Users { get; init; }
        public EnterpriseTypeRepository EnterpriseTypes { get; init; }
        public ManagementTerritoryRepository ManagementTerritories { get; init; }
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Enterprises = new EnterpriseRepository(context);
            Registrations = new RegistrationRepository(context);
            Users = new UserRepository(context);
            EnterpriseTypes = new EnterpriseTypeRepository(context);
            ManagementTerritories = new ManagementTerritoryRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
