using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
