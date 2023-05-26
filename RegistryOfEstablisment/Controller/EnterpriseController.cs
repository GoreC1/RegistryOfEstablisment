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
    public class EnterpriseController : BaseController
    {
        public EnterpriseController(IUnitOfWork unit) : base(unit) { }
        public void AddEnterprise(Enterprise ent)
        {
            _unit.Enterprises.Add(ent);
        }
        public Enterprise GetEnterprise(int enterpriseID)
        {
            return _unit.Enterprises.GetById(enterpriseID);
        }

        public List<ValueTuple<Enterprise, bool>> GetRegistriesList()
        {
            return _unit.Enterprises.GetAccessedRegistries();
        }
    }
}
