using RegistryOfEstablisment.Model;
using RegistryOfEstablisment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryOfEstablisment.UnitOfWork
{
    class UnitOfWork
    {
        private readonly DataContext _context;
        public EnterpriseRepository Products { get; init; }
        public RegistrationRepository Categories { get; init; }

        public UserRepository Users { get; init; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            //Products = new ProductRepository(context);
            //Categories = new CategoriesRepository(context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
