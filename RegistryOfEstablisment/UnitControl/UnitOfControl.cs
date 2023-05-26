using RegistryOfEstablisment.Controller;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.UnitControl
{
    public class UnitOfControl : IUnitOfControl
    {
        public AuthController AuthController { get; init; }

        public EnterpriseController EnterpriseController { get; init; }

        public RegistrationController RegistrationController { get; init; }

        public RegistryController RegistryController { get; init; }

        internal UnitOfControl(IUnitOfWork _unit)
        {
            AuthController = new(_unit);
            EnterpriseController = new(_unit);
            RegistrationController = new(_unit);
            RegistryController = new(_unit);
        }
    }
}
