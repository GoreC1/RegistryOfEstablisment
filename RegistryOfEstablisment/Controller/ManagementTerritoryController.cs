using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System.Collections.Generic;

namespace RegistryOfEstablisment.Controller
{
    public class ManagementTerritoryController : BaseController
    {
        public ManagementTerritoryController(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<ManagementTerritory> GetAccessedTerritories()
        {
            return _unit.ManagementTerritories.GetAccessedTerritories();
        }
        public IEnumerable<ManagementTerritory> GetTerritories()
        {
            return _unit.ManagementTerritories.GetAll();
        }
    }
}
