﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class CategoryMap:BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(q => q.Name).HasMaxLength(500).IsRequired();

        }
    }
}
