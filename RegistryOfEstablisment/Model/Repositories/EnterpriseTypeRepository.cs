using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class EnterpriseTypeRepository : GenericRepository<EnterpriseType>
    {
        public EnterpriseTypeRepository(DataContext context) : base(context) { }
    }
}
