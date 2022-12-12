using Microsoft.VisualBasic.ApplicationServices;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    public class RegistrationController : BaseController
    {
        public RegistrationController(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<Registration> GetRegistrationsByDayAndEnterprise(DateTime date, Enterprise ent)
        {
            return _unit.Registrations.GetAllByDayAndEnterprise(date, ent);
        }

        public void AddNewRegistration(Registration reg)
        {
            _unit.Registrations.Add(reg);
        }
    }
}
