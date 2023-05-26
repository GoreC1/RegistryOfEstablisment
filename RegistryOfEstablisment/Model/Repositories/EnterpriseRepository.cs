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
        public List<Enterprise> GetAccessedRegistries()
        {
            return null;
        }

        public void Add(Enterprise enterprise) 
        { 
            //добавляет новое предприятие
        }

        public Enterprise GetByID(int enterpriseID)
        {
            return null;
        }

        public void Remove(int enterpriseID) 
        { 
            //удаляет предприятие
        }

        public void Update(Enterprise enterprise) 
        {
            //обновляет информацию предприятия
        }
    }
}
