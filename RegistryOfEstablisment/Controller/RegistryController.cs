using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    class RegistryController
    {
        public List<Enterprise> GetRegistriesList()
        {
            EnterpriseRepository.GetAccessedRegistries();
            return null;
        }
    }
}
