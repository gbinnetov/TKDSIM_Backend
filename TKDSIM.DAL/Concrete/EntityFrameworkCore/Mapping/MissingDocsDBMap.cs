using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class MissingDocsDBMap : IEntityTypeConfiguration<MissingDocs>
    {
        public void Configure(EntityTypeBuilder<MissingDocs> builder)
        {
            builder.ToTable(@"missing_docs", @"dbo");
            builder.HasKey(d => d.M_ID);

            builder.Property(d => d.A_ID).HasColumnName("a_id");
            builder.Property(d => d.DocName).HasColumnName("doc_name");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
