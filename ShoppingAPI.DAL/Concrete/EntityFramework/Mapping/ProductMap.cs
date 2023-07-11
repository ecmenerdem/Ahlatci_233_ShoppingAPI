using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class ProductMap:BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(400).IsRequired();
            //builder.Property(q=>q.Description).IsRequired();
            builder.HasOne(q => q.Category).WithMany(q => q.Products).HasForeignKey(q => q.CategoryID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
