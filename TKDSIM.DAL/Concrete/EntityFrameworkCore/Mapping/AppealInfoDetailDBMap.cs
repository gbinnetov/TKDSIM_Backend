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
            
            builder.Property(d => d.DeqkisDate).HasColumnName("deqkis_date");


            builder.Property(d => d.Region).HasColumnName("region");
            builder.Property(d => d.IED_EV).HasColumnName("ied_ev");
            builder.Property(d => d.Address).HasColumnName("address");
            builder.Property(d => d.ApplicantType).HasColumnName("applicant_type");
            builder.Property(d => d.PropertType).HasColumnName("propert_type");
            builder.Property(d => d.AppealType).HasColumnName("appeal_type");
            builder.Property(d => d.ApplicantName).HasColumnName("applicant_name");
            builder.Property(d => d.DeqkisNo).HasColumnName("deqkis_no");
            builder.Property(d => d.GrandAreaSize).HasColumnName("grand_area_size");
            builder.Property(d => d.GrandCategory).HasColumnName("grand_category");
            builder.Property(d => d.WillChangeCategory).HasColumnName("will_change_category");
          //  builder.Property(d => d.UqodyaGC).HasColumnName("uqodiya_gc");
            builder.Property(d => d.UqodyaWCC).HasColumnName("uqodiya_wcc");
            // builder.Property(d => d.Planting).HasColumnName("planting");
            builder.Property(d => d.AppealReason).HasColumnName("appeal_reason");
            builder.Property(d => d.MainApplicantName).HasColumnName("main_applicant_name");
            builder.Property(d => d.AppealContent).HasColumnName("appealContent");

        }
    }
}
