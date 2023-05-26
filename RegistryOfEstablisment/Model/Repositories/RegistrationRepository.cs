using Microsoft.EntityFrameworkCore;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistryOfEstablisment.Model.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>
    {
        public RegistrationRepository(DataContext context) : base(context) { }

        public IEnumerable<Registration> GetAllByDayAndEnterprise(DateTime date, Enterprise ent)
        {
            return _context.Set<Registration>().Where(c => c.AppointmentTime.Day == date.Day && c.Enterprise == ent)
                                               .Include(c => c.Enterprise)
                                               .ToList();
        }
    }
}
