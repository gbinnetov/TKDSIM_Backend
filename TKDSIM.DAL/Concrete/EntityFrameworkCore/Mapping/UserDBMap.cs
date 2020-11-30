using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping
{
    public class UserDBMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"user", @"dbo");
            builder.HasKey(d => d.U_ID);

            builder.Property(d => d.FirstName).HasColumnName("first_name");
            builder.Property(d => d.LastName).HasColumnName("last_name");
            builder.Property(d => d.UserName).HasColumnName("user_name");
            builder.Property(d => d.Password).HasColumnName("password");
            builder.Property(d => d.Position).HasColumnName("position");
            builder.Property(d => d.InsertDate).HasColumnName("insert_date");
            builder.Property(d => d.UpadateDate).HasColumnName("update_date");
            builder.Property(d => d.DeleteDate).HasColumnName("delete_date");

        }
    }
}
