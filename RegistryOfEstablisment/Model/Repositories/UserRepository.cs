using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System.Linq;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class UserRepository : GenericRepository<User>
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
