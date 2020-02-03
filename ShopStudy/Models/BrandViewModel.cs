using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.NewDomain.Entities.Base.Interfaces;

namespace ShopStudy.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
    }
}
