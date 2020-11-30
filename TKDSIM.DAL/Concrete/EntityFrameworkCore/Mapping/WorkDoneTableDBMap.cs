using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkDoneTableDBMap : IEntityTypeConfiguration<WorkDoneTable>
    {
        public void Configure(EntityTypeBuilder<WorkDoneTable> builder)
        {
            builder.ToTable(@"work_done_table", @"dbo");
            builder.HasKey(d => d.WT_ID);

            builder.Property(d => d.A_ID).HasColumnName("a_id");
            builder.Property(d => d.LatterNo).HasColumnName("letter_no");
            builder.Property(d => d.Content).HasColumnName("content");
            builder.Property(d => d.SendingToWhom).HasColumnName("sending_to_whom");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");

        }
    }
}
