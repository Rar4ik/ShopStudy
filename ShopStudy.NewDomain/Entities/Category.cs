using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;
using ShopStudy.NewDomain.Entities.Base;
using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.NewDomain.Entities
{
    [Table("Categories")]
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии)
        /// </summary>
        public int? ParentId { get; set; }
        public int Order { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}