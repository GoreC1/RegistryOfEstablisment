using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment.Controller
{
    public class AuthController
    {
        private readonly IUnitOfWork _unit;

        public AuthController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public bool Authentificate(string login, string password)
        {
            User authUser = _unit.Users.GetByAuth(login, password);
            if (authUser == null)
                return false;
            CurrentUser.Role = authUser.Role;
            CurrentUser.ManagementTerritory = authUser.ManagementTerritory;
            CurrentUser.OwnedEnterprise = authUser.OwnedEnterprise;
            CurrentUser.Login = authUser.Login;
            CurrentUser.Password = authUser.Password;
            CurrentUser.TelephoneNumber = authUser.TelephoneNumber;
            CurrentUser.Address = authUser.Address;
            return true;
        }
    }
}
