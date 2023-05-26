using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class EnterpriseRepository : GenericRepository<Enterprise>
    {
        public EnterpriseRepository(DataContext context) : base(context) { }

        public new IEnumerable<Enterprise> Find(Expression<Func<Enterprise, bool>> expression)
        {
            return _context.Set<Enterprise>().Where(expression);
        }

        public IEnumerable<Enterprise> GetFilteredEnterprises(Expression<Func<Enterprise, bool>>[] filters, int index, int count)
        {
            var query = _context.Enterprises
                                .AsQueryable()
                                .AsNoTracking();

            if (filters != null)
            {
                foreach (var filter in filters) query = query.Where(filter);
            }

            return query.Include(c => c.ManagementTerritory)
                        .Include(c => c.Type)
                        .Skip(index)
                        .Take(count)
                        .OrderBy(t => t.Id)
                        .ToList();
        }

        public int GetFilteredCount(Expression<Func<Enterprise, bool>>[] filters)
        {
            var query = _context.Enterprises
                    .AsQueryable()
                    .AsNoTracking();

            if (filters != null)
            {
                foreach (var filter in filters) query = query.Where(filter);
            }

            return query.Count();
        }

        public IEnumerable<Enterprise> GetSome(int index, int count)
        {
            return _context.Set<Enterprise>().Include(c => c.ManagementTerritory)
                                             .Include(c => c.Type)
                                             .Skip(index)
                                             .Take(count)
                                             .ToList();
        }

        public new IEnumerable<Enterprise> GetAll()
        {
            return _context.Set<Enterprise>().Include(c => c.ManagementTerritory)
                                             .Include(c => c.Type)
                                             .ToList();
        }

        public new Enterprise GetById(int id)
        {
            return _context.Set<Enterprise>().Where(c => c.Id == id)
                                             .Include(c => c.ManagementTerritory)
                                             .Include(c => c.Type)
                                             .FirstOrDefault();
        }

        public bool CheckAccess(Enterprise ent)
        {
            switch (CurrentUser.Role.Name)
            {
                case "Оператор ОМСУ":
                    {
                        List<string> accessedTypes = new()
                        {
                            "Приют",
                            "Организация по отлову",
                            "Организация по отлову и приют",
                            "Организация по транспортировке",
                            "Ветеринарная клиника: муниципальная",
                            "Ветеринарная клиника: частная",
                            "Благотворительный фонд",
                            "Организации по продаже товаров и предоставлению услуг для животных"
                        };
                        return accessedTypes.Contains(ent.Type.Name) && ent.ManagementTerritory.Name == CurrentUser.ManagementTerritory.Name;
                    }
                case "Оператор ВетСлужбы":
                    {
                        List<string> accessedTypes = new() { "Исполнительный орган государственной власти", "Орган местного самоуправления", "Ветеринарная клиника: государственная" };
                        return accessedTypes.Contains(ent.Type.Name);
                    }
                case "Куратор ВетСлужбы":
                case "Куратор ОМСУ":
                case "Куратор по отлову":
                case "Куратор приюта":
                case "Подписант ВетСлужбы":
                case "Подписант ОМСУ":
                case "Подписант по отлову":
                case "Подписант приюта":
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public List<ValueTuple<Enterprise, bool>> GetAccessedRegistry(List<Enterprise> list)
        {
            List<ValueTuple<Enterprise, bool>> result = new();
            switch (CurrentUser.Role.Name)
            {
                case "Оператор ОМСУ":
                    {
                        List<string> accessedTypes = new()
                        {
                            "Приют",
                            "Организация по отлову",
                            "Организация по отлову и приют",
                            "Организация по транспортировке",
                            "Ветеринарная клиника: муниципальная",
                            "Ветеринарная клиника: частная",
                            "Благотворительный фонд",
                            "Организации по продаже товаров и предоставлению услуг для животных"
                        };
                        foreach (Enterprise ent in list)
                        {
                            result.Add((ent, ent.ManagementTerritory.Name == CurrentUser.ManagementTerritory.Name && accessedTypes.Contains(ent.Type.Name)));
                        }
                        break;
                    }
                case "Оператор ВетСлужбы":
                    {
                        List<string> accessedTypes = new() { "Исполнительный орган государственной власти", "Орган местного самоуправления", "Ветеринарная клиника: государственная" };
                        foreach (Enterprise ent in list)
                        {
                            result.Add((ent, accessedTypes.Contains(ent.Type.Name)));
                        }
                        break;
                    }
                case "Куратор ВетСлужбы":
                case "Куратор ОМСУ":
                case "Куратор по отлову":
                case "Куратор приюта":
                case "Подписант ВетСлужбы":
                case "Подписант ОМСУ":
                case "Подписант по отлову":
                case "Подписант приюта":
                    {
                        foreach (Enterprise ent in list)
                        {
                            result.Add((ent, false));
                        }
                        break;
                    }
                default:
                    break;
            }
            return result;
        }

        public void Update(Enterprise newEnterprise)
        {
            var newEnt = _context.Enterprises.Where(c => c.Id== newEnterprise.Id).FirstOrDefault();

            newEnt.Name = newEnterprise.Name;
            newEnt.Type = newEnterprise.Type;
            newEnt.ITN = newEnterprise.ITN;
            newEnt.ManagementTerritory = newEnterprise.ManagementTerritory;
            newEnt.Address = newEnterprise.Address;
            newEnt.RealAddress = newEnterprise.RealAddress;
            newEnt.LegalEntity = newEnterprise.LegalEntity;
            newEnt.Checkpoint = newEnterprise.Checkpoint;
            newEnt.TelephoneNumber = newEnterprise.TelephoneNumber;
            newEnt.Email = newEnterprise.Email;
            newEnt.WebSite = newEnterprise.WebSite;

            _context.SaveChanges();
        }
    }
}
