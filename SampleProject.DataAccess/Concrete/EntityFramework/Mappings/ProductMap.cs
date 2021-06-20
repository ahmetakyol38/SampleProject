using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Entities.Concrete;

namespace SampleProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Price).HasColumnName("Price");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
        }
    }
}
