using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Entities
{
    public class User : BaseEntity
    {
        public Role Role { get; set; }
        public ManagementTerritory ManagementTerritory { get; set; }
        public Enterprise OwnedEnterprise { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
    }
}
