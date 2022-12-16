using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLog;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;

namespace RegistryOfEstablisment.Controller
{
    public class EnterpriseController : BaseController
    {

        public EnterpriseController(IUnitOfWork unit) : base(unit) { }
        
        public void AddEnterprise(Enterprise ent)
        {
            _logger.Trace($"Контроллер запрашивает создание организации у репозитория");
            _unit.Enterprises.Add(ent);
            _logger.Info($"Организация [ID = {ent.Id}] успешно создана");
        }

        public Enterprise GetEnterpriseByID(int enterpriseID)
        {
            return _unit.Enterprises.GetById(enterpriseID);
        }

        public List<ValueTuple<Enterprise, bool>> GetFilteredEnterprises(Expression<Func<Enterprise, bool>>[] filters, int index, int count)
        {
            return _unit.Enterprises.GetAccessedRegistry(_unit.Enterprises.GetFilteredEnterprises(filters, index, count).ToList()).ToList();
        }

        public int GetFilteredCount(Expression<Func<Enterprise, bool>>[] filters)
        {
            return _unit.Enterprises.GetFilteredCount(filters);
        }

        public int GetCount()
        {
            return _unit.Enterprises.GetCount();
        }

        public List<ValueTuple<Enterprise, bool>> GetRegistryList(int index, int count)
        {
            return _unit.Enterprises.GetAccessedRegistry(_unit.Enterprises.GetSome(index, count).ToList()).ToList();
        }

        public void UpdateEnterprise(Enterprise newEnterprise)
        {
            var oldEnt = GetEnterpriseByID(newEnterprise.Id);
            _logger.Trace($"Контроллер запрашивает изменение организации [ID = {newEnterprise.Id}] у репозитория");
            _unit.Enterprises.Update(newEnterprise);
            _logger.Info($"Организация успешно изменена");
        }

        public Enterprise GetLastEnterprise()
        {
            return _unit.Enterprises.GetLastEnterprise();
        }

        public void DeleteEnterprise(int enterpriseID)
        {
            _logger.Trace($"Контроллер запрашивает удаление организации [ID = {enterpriseID}] у репозитория");
            _unit.Enterprises.Remove(GetEnterpriseByID(enterpriseID));
            _logger.Info($"Организация успешно удаление");
        }
    }
}
