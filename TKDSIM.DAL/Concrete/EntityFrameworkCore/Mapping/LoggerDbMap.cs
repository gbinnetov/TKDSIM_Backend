using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class LoggerDbMap : IEntityTypeConfiguration<Logger>
    {
        public void Configure(EntityTypeBuilder<Logger> builder)
        {
            builder.ToTable(@"logger", @"dbo");
            builder.HasKey(d => d.L_ID);

            builder.Property(d => d.U_ID).HasColumnName("u_id");
            builder.Property(d => d.T_ID).HasColumnName("t_id");
            builder.Property(d => d.TableName).HasColumnName("table_name");
            builder.Property(d => d.OperationDate).HasColumnName("operation_date");
            builder.Property(d => d.OperationType).HasColumnName("operation_type");
        }
    }
}
