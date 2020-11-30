using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class SubmittedDocsDBMap : IEntityTypeConfiguration<SubmittedDocs>
    {
        public void Configure(EntityTypeBuilder<SubmittedDocs> builder)
        {
            builder.ToTable(@"submitted_docs", @"dbo");
            builder.HasKey(d => d.S_ID);

            builder.Property(d => d.A_ID).HasColumnName("a_id");
            builder.Property(d => d.DocName).HasColumnName("doc_name");
            builder.Property(d => d.DeqkisNo).HasColumnName("deqkis_no");
            builder.Property(d => d.PresentationDate).HasColumnName("presentation_date");
            builder.Property(d => d.FilePath).HasColumnName("file_path");
            builder.Property(d => d.FileName).HasColumnName("file_name");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");
        }
    }
}
