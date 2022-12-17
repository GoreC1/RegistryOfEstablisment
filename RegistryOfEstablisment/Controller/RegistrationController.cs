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
        public RegistrationController(IUnitOfWork unit) : base(unit) { }

        public IEnumerable<Registration> GetRegistrationsByDayAndEnterprise(DateTime date, Enterprise ent)
        {
            return _unit.Registrations.GetAllByDayAndEnterprise(date, ent);
        }

        public void AddNewRegistration(Registration reg)
        {
            _logger.Trace($"Контроллер запрашивает создание регистрации {reg.User} - {reg.Enterprise} у репозитория");
            _unit.Registrations.Add(reg);
            _logger.Info($"Регистрация успешно создана. ID пользователя - {reg.User.Id}, ID организации - {reg.Enterprise.Id}, Питомец - {reg.PetName}, Время - {reg.AppointmentTime}");
        }
    }
}
