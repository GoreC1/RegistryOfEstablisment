using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    class EnterpriseRepository : GenericRepository<Enterprise>
    {
        public EnterpriseRepository(DataContext context) : base(context) { }

        public new IEnumerable<Enterprise> Find(Expression<Func<Enterprise, bool>> expression)
        {
            return _context.Set<Enterprise>().Where(expression);
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

        public List<ValueTuple<Enterprise,bool>> GetAccessedRegistries()
        {
            List<Enterprise> list = GetAll().ToList();
            List<ValueTuple<Enterprise,bool>> result = new();
            switch (CurrentUser.Role.Name)
            {
                case "Оператор ОМСУ":
                    {
                        List<string> accessedTypes = new() { "Приют", "Организация по отлову", "Организация по отлову и приют" };
                        foreach (Enterprise ent in list)
                        {
                            result.Add((ent, ent.ManagementTerritory == CurrentUser.ManagementTerritory && accessedTypes.Contains(ent.Type.Name)));
                        }
                        break;
                    }
                case "Оператор ВетСлужбы":
                    {
                        List<string> accessedTypes = new() { "Исполнительный орган государственной власти", "Орган местного самоуправления", "Ветеринарная клиника: государственная"};
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
    }
}
