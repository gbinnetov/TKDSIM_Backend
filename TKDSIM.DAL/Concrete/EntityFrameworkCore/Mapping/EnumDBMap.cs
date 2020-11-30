using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using EntityUsing = TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class EnumDBMap : IEntityTypeConfiguration<EntityUsing.Enum>
    {
        public void Configure(EntityTypeBuilder<EntityUsing.Enum> builder)
        {
            builder.ToTable(@"_enum", @"dbo");
            builder.HasKey(d => d.E_ID);

            builder.Property(d => d.Val).HasColumnName("val");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
