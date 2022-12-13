using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class EnterpriseTypeRepository : GenericRepository<EnterpriseType>
    {
        public EnterpriseTypeRepository(DataContext context) : base(context) { }

        public List<EnterpriseType> GetAccessedTypes()
        {
            List<EnterpriseType> types = new();
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

                        types.AddRange(_context.EnterpriseTypes.Where(c => accessedTypes.Contains(c.Name)));
                        return types;
                    }
                case "Оператор ВетСлужбы":
                    {
                        List<string> accessedTypes = new() 
                        { 
                            "Исполнительный орган государственной власти", 
                            "Орган местного самоуправления", 
                            "Ветеринарная клиника: государственная" 
                        };
                        
                        types.AddRange(_context.EnterpriseTypes.Where(c => accessedTypes.Contains(c.Name)));
                        return types;
                    }
                default:
                    return types;
            }
        }

        public bool IsForRegistration(EnterpriseType type)
        {
            switch (type.Name)
            {
                case "Приют":
                case "Организация по отлову и приют":
                case "Ветеринарная клиника: государственная ":
                case "Ветеринарная клиника: муниципальная":
                case "Ветеринарная клиника: частная":
                case "Организации по продаже товаров и предоставлению услуг для животных":
                    return true;
                default:
                    return false;
            }
        }
    }
}
