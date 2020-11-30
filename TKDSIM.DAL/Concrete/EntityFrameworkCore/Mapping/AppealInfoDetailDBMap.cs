using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class AppealInfoDetailDBMap : IEntityTypeConfiguration<AppealInfoDetail>
    {
        public void Configure(EntityTypeBuilder<AppealInfoDetail> builder)
        {
            builder.ToTable(@"appeal_info_detail", @"dbo");
            builder.HasKey(d => d.ID);

            builder.Property(d => d.A_ID).HasColumnName("A_ID");
            builder.Property(d => d.DeqkisNo).HasColumnName("deqkis_no");
            builder.Property(d => d.PropertType).HasColumnName("propert_type");
            builder.Property(d => d.AppealType).HasColumnName("appeal_type");
            builder.Property(d => d.GrandCategory).HasColumnName("grand_category");
            builder.Property(d => d.UqodiyaGC).HasColumnName("uqodiya_gc");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");

        }
    }
}
