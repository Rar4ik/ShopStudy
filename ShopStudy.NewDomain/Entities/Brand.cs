using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ShopStudy.NewDomain.Entities.Base;
using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.NewDomain.Entities
{
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public  int Amount { get; set; }

        public virtual ICollection<Product> Products{ get; set; }
    }
}