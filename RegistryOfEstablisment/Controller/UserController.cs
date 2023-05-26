using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment.Controller
{
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unit) : base(unit) { }
        public User GetUserById(int id)
        {
            return _unit.Users.GetById(id);
        }

        public bool IsAccessible(Enterprise ent)
        {
            return _unit.Enterprises.CheckAccess(ent);
        }
    }
}
