using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Unit
{
    internal interface IUnitOfWork : IDisposable
    {
        public EnterpriseRepository Enterprises { get; }
        public RegistrationRepository Registrations { get; }
        public UserRepository Users { get; }
        public EnterpriseTypeRepository EnterpriseTypes { get; }
        public ManagementTerritoryRepository ManagementTerritories { get; }
    }
}
