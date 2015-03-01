using WebApi.Data.Entities.Interfaces;

namespace WebApi.Data.Entities.Bases
{
    public abstract class EntityBase : IEntity
    {
        public string ID { get; set; }
    }
}
