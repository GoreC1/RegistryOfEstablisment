using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Entities
{
    static class CurrentUser 
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static Role Role { get; set; }
        public static ManagementTerritory ManagementTerritory { get; set; }
        public static Enterprise OwnedEnterprise { get; set; }
        public static string TelephoneNumber { get; set; }
        public static string Address { get; set; }
    }
}
