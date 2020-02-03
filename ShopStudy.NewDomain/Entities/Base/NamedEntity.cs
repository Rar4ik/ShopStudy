using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.NewDomain.Entities.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
