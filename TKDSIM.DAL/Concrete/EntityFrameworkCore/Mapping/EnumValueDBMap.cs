using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class EnumValueDBMap : IEntityTypeConfiguration<EnumValue>
    {
        public void Configure(EntityTypeBuilder<EnumValue> builder)
        {
            builder.ToTable(@"_enum_val", @"dbo");
            builder.HasKey(d => d.EV_ID);

            builder.Property(d => d.E_ID).HasColumnName("e_id");
            builder.Property(d => d.Value).HasColumnName("val");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
