using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class OrderProjectDBMap : IEntityTypeConfiguration<OrderProject>
    {
        public void Configure(EntityTypeBuilder<OrderProject> builder)
        {
            builder.ToTable(@"order_project", @"dbo");
            builder.HasKey(d => d.O_ID);

            builder.Property(d => d.A_ID).HasColumnName("a_id");
            builder.Property(d => d.OrderNo).HasColumnName("order_no");
            builder.Property(d => d.OrderStatus).HasColumnName("order_status");
            builder.Property(d => d.OrderStatusNote).HasColumnName("order_status_note");
            builder.Property(d => d.DocumentNo).HasColumnName("document_no");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
