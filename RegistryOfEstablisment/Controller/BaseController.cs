using RegistryOfEstablisment.Unit;

namespace RegistryOfEstablisment.Controller
{
    public class BaseController : IBaseController
    {
        protected readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}
