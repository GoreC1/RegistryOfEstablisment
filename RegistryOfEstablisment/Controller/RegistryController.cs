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
    public class RegistryController
    {
        private readonly IUnitOfWork _unit;

        internal RegistryController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public List<ValueTuple<Enterprise,bool>> GetRegistriesList()
        {
            return _unit.Enterprises.GetAccessedRegistries();
        }

        public IEnumerable<EnterpriseType> GetTypes()
        {
            return _unit.EnterpriseTypes.GetAll();
        }

        public IEnumerable<ManagementTerritory> GetTerritories()
        {
            return _unit.ManagementTerritories.GetAll();
        }
    }
}
