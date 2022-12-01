using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Entities
{
    public class Registration : BaseEntity
    {
        public User User { get; set; }
        public Enterprise Enterprise { get; set; }
        public  DateTime AppointmentTime { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
    }
}
