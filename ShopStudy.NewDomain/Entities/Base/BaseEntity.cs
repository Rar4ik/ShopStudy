using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.NewDomain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
