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
    public class OrderMap:BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasOne(q => q.User).WithMany(q => q.Orders).HasForeignKey(q => q.UserID).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(q => q.OrderDetails).WithOne(q => q.Order).HasForeignKey(q => q.OrderID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
