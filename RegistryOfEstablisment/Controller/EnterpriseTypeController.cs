using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    public class EnterpriseTypeController : BaseController
    {
        public EnterpriseTypeController(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<EnterpriseType> GetTypes()
        {
            return _unit.EnterpriseTypes.GetAll();
        }

    }
}
