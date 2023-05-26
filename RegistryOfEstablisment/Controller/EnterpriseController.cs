using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegistryOfEstablisment.Controller
{
    public class EnterpriseController : BaseController
    {
        public EnterpriseController(IUnitOfWork unit) : base(unit) { }
        public void AddEnterprise(Enterprise ent)
        {
            _unit.Enterprises.Add(ent);
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
    }
}
