using RegistryOfEstablisment.Model.Repositories;
using System;

namespace RegistryOfEstablisment.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        public EnterpriseRepository Enterprises { get; }
        public RegistrationRepository Registrations { get; }
        public UserRepository Users { get; }
        public EnterpriseTypeRepository EnterpriseTypes { get; }
        public ManagementTerritoryRepository ManagementTerritories { get; }
    }
}
