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
    public class UserMap:BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q => q.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(q => q.LastName).HasMaxLength(100).IsRequired();
            builder.Property(q => q.UserName).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(20).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Phone).HasMaxLength(12).IsRequired();
            builder.Property(q => q.Adress).IsRequired();
            //builder.HasMany(q => q.Orders).WithOne(q => q.User).HasForeignKey(q => q.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
