using RegistryOfEstablisment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.UnitControl
{
    public interface IUnitOfControl
    {
        AuthController AuthController { get; }
        EnterpriseController EnterpriseController { get; }
        RegistrationController RegistrationController { get; }
        RegistryController RegistryController { get; }
    }
}
