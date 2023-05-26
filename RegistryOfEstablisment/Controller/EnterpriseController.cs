using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    class EnterpriseController
    {
        public void AddEnterprise(Enterprise e)
        {
            EnterpriseRepository.Add(e);
        }

        public Enterprise GetEnterpise(int enterpriseID)
        {
            RegistrationRepository.GetAllByID(enterpriseID);    
            return null;
        }

        public List<Registration> GetRegistrations(int enterpriseID)
        {
            RegistrationRepository.GetAllByID(enterpriseID);
            return null;
        }

        public void DeleteEnterprise(int enterpriseID) 
        {
            EnterpriseRepository.Remove(enterpriseID);
        }

        public void UpdateEnterprise(Enterprise enterprise)
        {
            EnterpriseRepository.Update(enterprise);
        }
    }
}
