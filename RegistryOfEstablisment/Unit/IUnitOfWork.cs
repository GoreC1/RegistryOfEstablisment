using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        EnterpriseRepository Enterprises { get; }
        RegistrationRepository Registrations { get; }
        UserRepository Users { get; }
    }
}
