using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopStudy.NewDomain.Entities;

namespace ShopStudy.Dal
{
    public class ShopStudyContext : DbContext
    {
        public ShopStudyContext(DbContextOptions options) : base(options)
        {
                
        }
        public  DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
