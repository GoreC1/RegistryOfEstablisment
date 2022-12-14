using RegistryOfEstablisment.Model.Interfaces;

namespace RegistryOfEstablisment.Model.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
