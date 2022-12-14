using RegistryOfEstablisment.Controller;

namespace RegistryOfEstablisment.UnitControl
{
    public interface IUnitOfControl
    {
        AuthController AuthController { get; }
        EnterpriseController EnterpriseController { get; }
        RegistrationController RegistrationController { get; }
        UserController UserController { get; }
        EnterpriseTypeController EnterpriseTypeController { get; }
        ManagementTerritoryController ManagementTerritoryController { get; }
    }
}
