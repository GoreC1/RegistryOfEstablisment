using NLog;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RegistryOfEstablisment.Controller
{
    public class RegistrationController : BaseController
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public RegistrationController(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<Registration> GetRegistrationsByDayAndEnterprise(DateTime date, Enterprise ent)
        {
            return _unit.Registrations.GetAllByDayAndEnterprise(date, ent);
        }

        public void AddNewRegistration(Registration reg)
        {
            Logger.Trace($"{TypeDescriptor.GetClassName(this)} запрашивает создание регистрации {reg.User} - {reg.Enterprise} у RegistrationRepository");
            _unit.Registrations.Add(reg);
            Logger.Info($"Регистрация {reg.User} - {reg.Enterprise} успешно создана");
        }
    }
}
