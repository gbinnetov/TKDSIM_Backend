using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
   public class WorkDoneFormDBMap : IEntityTypeConfiguration<WorkDoneForm>
    {
        public void Configure(EntityTypeBuilder<WorkDoneForm> builder)
        {
            builder.ToTable(@"work_done_form", @"dbo");
            builder.HasKey(d => d.WF_ID);

            builder.Property(d => d.A_ID).HasColumnName("a_id");
            builder.Property(d => d.PlaceStructureOrderNo).HasColumnName("place_structure_order_no");
            builder.Property(d => d.PlaceStructureOrderStatus).HasColumnName("place_structure_order_status");
            builder.Property(d => d.PlaceStructureOrderNote).HasColumnName("place_structure_order_status_note");
            builder.Property(d => d.PlaceStructurePlanDeqkisNo).HasColumnName("place_structure_plan_deqkis_no");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
