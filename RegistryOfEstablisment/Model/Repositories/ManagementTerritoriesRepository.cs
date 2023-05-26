using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class ManagementTerritoryRepository : GenericRepository<ManagementTerritory>
    {
        public ManagementTerritoryRepository(DataContext context) : base(context) { }
    }
}
