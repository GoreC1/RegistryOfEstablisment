using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        EnterpriseRepository Products { get; }
        RegistrationRepository Categories { get; }

        UserRepository Users { get; }
        Task<int> Complete();
    }
}
