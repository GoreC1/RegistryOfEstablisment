using Microsoft.VisualBasic.ApplicationServices;
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
    public class RegistrationController
    {
        private readonly IUnitOfWork _unit;

        internal RegistrationController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        //public void AddNewRegistration(DateTime date, string petName, string petType)
        //{
        //    Registration re = new Registration();
        //    RegistrationRepository.Add(re);
        //}
    }
}
