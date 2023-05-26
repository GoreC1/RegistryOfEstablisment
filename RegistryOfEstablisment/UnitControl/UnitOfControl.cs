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

        public UserController UserController { get; init; }

        public EnterpriseTypeController EnterpriseTypeController { get; init; }

        public ManagementTerritoryController ManagementTerritoryController { get; init; }

        internal UnitOfControl(IUnitOfWork _unit)
        {
            AuthController = new(_unit);
            EnterpriseController = new(_unit);
            RegistrationController = new(_unit);
            UserController = new(_unit);
            EnterpriseTypeController = new(_unit);
            ManagementTerritoryController = new(_unit);
        }
    }
}
