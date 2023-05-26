using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    public class EnterpriseController
    {
        readonly IUnitOfWork _unit;

        internal EnterpriseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public void AddEnterprise(Enterprise ent)
        {
            _unit.Enterprises.Add(ent);
        }
        public Enterprise GetEnterprise(int enterpriseID)
        {
            return _unit.Enterprises.GetById(enterpriseID);
        }

        //public List<Registration> GetRegistrations(int enterpriseID)
        //{
        //    RegistrationRepository.GetAllByID(enterpriseID);
        //    return null;
        //}

        //public void DeleteEnterprise(int enterpriseID) 
        //{
        //    EnterpriseRepository.Remove(enterpriseID);
        //}

        //public void UpdateEnterprise(Enterprise enterprise)
        //{
        //    EnterpriseRepository.Update(enterprise);
        //}
    }
}
