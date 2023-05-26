using RegistryOfEstablisment.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class ManagementTerritoryRepository : GenericRepository<ManagementTerritory>
    {
        public ManagementTerritoryRepository(DataContext context) : base(context) { }

        public IEnumerable<ManagementTerritory> GetAccessedTerritories()
        {
            switch (CurrentUser.Role.Name)
            {
                case "Оператор ОМСУ":
                    {
                        return _context.ManagementTerritories.Where(c => c.Name == CurrentUser.ManagementTerritory.Name);
                    }
                case "Оператор ВетСлужбы":
                    {
                        return GetAll();
                    }
                default:
                    return default;
            }
        }
    }
}
