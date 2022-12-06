using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DataContext context) : base(context) { }

        public User GetByAuth(string login, string password)
        {
            return _context.Users.FirstOrDefault(c => c.Login == login && c.Password == password);
        }
    }
}
