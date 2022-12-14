using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment.Controller
{
    public class AuthController : BaseController
    {
        public AuthController(IUnitOfWork unit) : base(unit) { }
        public bool Authentificate(string login, string password)
        {
            User authUser = _unit.Users.GetByAuth(login, password);
            if (authUser == null)
                return false;
            CurrentUser.Id = authUser.Id;
            CurrentUser.Name = authUser.Name;
            CurrentUser.Role = authUser.Role;
            CurrentUser.ManagementTerritory = authUser.ManagementTerritory;
            CurrentUser.TelephoneNumber = authUser.TelephoneNumber;
            CurrentUser.Address = authUser.Address;
            return true;
        }
    }
}
