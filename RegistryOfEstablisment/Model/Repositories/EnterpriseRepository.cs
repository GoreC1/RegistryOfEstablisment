using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class EnterpriseRepository
    {
        DataContext DC = new DataContext();
        public static List<Enterprise> GetAccessedRegistries()
        {
            return null;
        }

        public static void Add(Enterprise enterprise) 
        { 
            //добавляет новое предприятие
        }

        public static Enterprise GetByID(int enterpriseID)
        {
            return null;
        }

        public static void Remove(int enterpriseID) 
        { 
            //удаляет предприятие
        }

        public static void Update(Enterprise enterprise) 
        {
            //обновляет информацию предприятия
        }
    }
}
