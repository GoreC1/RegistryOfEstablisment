using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    class UserRepository
    {
        DataContext DC = new DataContext();

        public static User GetByAuth(string login, string password)
        {
            //Обращается к базе данных и получает нужного пользователя
            if () //если нашёл 
            {
               User user = new User();
               return user;
            } 
            else //если не нашёл
            {
                return null;
            }

        }
    }
}
