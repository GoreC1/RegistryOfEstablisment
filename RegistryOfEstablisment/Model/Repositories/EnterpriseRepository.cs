using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class EnterpriseRepository : GenericRepository<Enterprise>
    {
        public EnterpriseRepository(DataContext context) : base(context) { }
        public List<Enterprise> GetAccessedRegistries()
        {
            return null;
        }
    }
}
