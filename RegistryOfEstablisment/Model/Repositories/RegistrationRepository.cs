using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>
    {
        public RegistrationRepository(DataContext context) : base(context) { }
    }
}
