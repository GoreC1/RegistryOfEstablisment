﻿using RegistryOfEstablisment.Model.Entities;
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
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public EnterpriseController(IUnitOfWork unit) : base(unit) { }
        public void AddEnterprise(Enterprise ent)
        {
            Logger.Trace($"{TypeDescriptor.GetClassName(this)} запрашивает создание организации {ent.Name} у EnterpriseRepository");
            _unit.Enterprises.Add(ent);
            Logger.Info($"Организация {ent.Name} успешно создана");
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
        public void DeleteEnterprise(int enterpriseID)
        {
            _unit.Enterprises.Remove(GetEnterpriseByID(enterpriseID));
        }

        public List<ValueTuple<Enterprise, bool>> GetRegistryList(int index, int count)
        {
            return _unit.Enterprises.GetAccessedRegistry(_unit.Enterprises.GetSome(index, count).ToList()).ToList();
        }

        public Enterprise GetLastEnterprise()
        {
            return _unit.Enterprises.GetLastEnterprise();
        }

        public void DeleteEnterprise(int enterpriseID)
        {
            Logger.Trace($"{TypeDescriptor.GetClassName(this)} запрашивает изменение организации [ID - {enterpriseID}]{GetEnterpriseByID(enterpriseID).Name} у EnterpriseRepository");
            _unit.Enterprises.Remove(GetEnterpriseByID(enterpriseID));
            Logger.Info($"Организация успешно изменена");
        }
    }
}
