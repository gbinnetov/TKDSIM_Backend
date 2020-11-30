using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class AdminUnitDBMap: IEntityTypeConfiguration<AdminUnit>
    {
        public void Configure(EntityTypeBuilder<AdminUnit> builder)
        {
            builder.ToTable(@"admin_unit", @"dbo");
            builder.HasKey(d => d.Admin_Unit_ID);

            builder.Property(d => d.ParentCode).HasColumnName("parent_code");
            builder.Property(d => d.Code).HasColumnName("code");
            builder.Property(d => d.Name).HasColumnName("name_az");
           
        }
    }
}
