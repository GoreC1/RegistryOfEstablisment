using NLog;
using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment.Controller
{
    public class BaseController
    {
        protected static Logger _logger = LogManager.GetCurrentClassLogger();
        
        protected readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}
