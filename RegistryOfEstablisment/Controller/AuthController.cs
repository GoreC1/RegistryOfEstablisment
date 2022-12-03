using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Controller
{
    class AuthController
    {
        public bool Authentificate (string login, string password)
        {
            if (UserRepository.GetByAuth(login, password) == null) 
            {
                return false;
            }
            else
            {
                User user = UserRepository.GetByAuth(login, password);
                user.Role = CurrentUser.Role;
                user.ManagementTerritory = CurrentUser.ManagementTerritory;
                user.OwnedEnterprise = CurrentUser.OwnedEnterprise;
                user.Login = CurrentUser.Login;
                user.Password = CurrentUser.Password;
                user.TelephoneNumber = CurrentUser.TelephoneNumber;
                user.Address = CurrentUser.Address;
                return true;
            }
    }
}
