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
        public static void AddEnterprise(Enterprise e)
        {
            EnterpriseRepository.Add(e);
        }

        public static Enterprise GetEnterpise(int enterpriseID)
        {
            RegistrationRepository.GetAllByID(enterpriseID);    
            return null;
        }

        public static List<Registration> GetRegistrations(int enterpriseID)
        {
            RegistrationRepository.GetAllByID(enterpriseID);
            return null;
        }

        public static void DeleteEnterprise(int enterpriseID) 
        {
            EnterpriseRepository.Remove(enterpriseID);
        }

        public static void UpdateEnterprise(Enterprise enterprise)
        {
            EnterpriseRepository.Update(enterprise);
        }
    }
}
