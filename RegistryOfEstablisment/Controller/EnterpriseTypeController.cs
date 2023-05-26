using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System.Collections.Generic;

namespace RegistryOfEstablisment.Controller
{
    public class EnterpriseTypeController : BaseController
    {
        public EnterpriseTypeController(IUnitOfWork unit) : base(unit) { }
        public IEnumerable<EnterpriseType> GetAccessedTypes()
        {
            return _unit.EnterpriseTypes.GetAccessedTypes();
        }

        public IEnumerable<EnterpriseType> GetAllTypes()
        {
            return _unit.EnterpriseTypes.GetAll();
        }


        public bool IsForRegistration(EnterpriseType type)
        {
            return _unit.EnterpriseTypes.IsForRegistration(type);
        }

    }
}
