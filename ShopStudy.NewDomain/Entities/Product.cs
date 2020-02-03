using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;
using ShopStudy.NewDomain.Entities.Base;
using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.NewDomain.Entities
{
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        [ForeignKey("BrandId")]
        public virtual Brand Brand{ get; set; }
    }
}
