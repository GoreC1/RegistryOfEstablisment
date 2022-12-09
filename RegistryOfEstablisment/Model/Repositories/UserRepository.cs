using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.Model.Repositories
{
    class UserRepository : GenericRepository<User>
    {
        public UserRepository(DataContext context) : base(context) { }

        public User GetByAuth(string login, string password)
        {
            User user = _context.Users
                                .Where(c => c.Login == login && c.Password == password)
                                .Include(c => c.ManagementTerritory)
                                .Include(c => c.Role)
                                .FirstOrDefault();
            return user;
        }
    }
}
