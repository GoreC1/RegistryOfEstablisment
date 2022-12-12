using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unit) : base(unit) { }
        public User GetUserById(int id)
        {
            return _unit.Users.GetById(id);
        }
    }
}
