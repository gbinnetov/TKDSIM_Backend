using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Mapping;
using TKDSIM.Entity.Entity;

namespace TKDSIM.DAL.Concrete.EntityFrameworkCore
{
    public class TKDSIMDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=10.0.6.25;Database=TKDSIM;MultipleActiveResultSets=true;User Id=sa; Password=byte");
          // optionsBuilder.UseSqlServer(@"Server=DESKTOP-6QLETL0;Database=TKDSIM;Trusted_Connection=True;MultipleActiveResultSets=true;");

        }

        public DbSet<AppealInfo> AppealInfos { get; set; }
        public DbSet<TKDSIM.Entity.Entity.Enum> Enums { get; set; }
        public DbSet<EnumValue> EnumValues { get; set; }
        public DbSet<Logger> Loggers { get; set; }
        public DbSet<MissingDocs> MissingDocs { get; set; }
        public DbSet<OrderProject> OrderProjects { get; set; }
        public DbSet<SubmittedDocs> SubmittedDocs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkDoneForm> WorkDoneForms { get; set; }
        public DbSet<WorkDoneTable> WorkDoneTables { get; set; }
        public DbSet<AdminUnit> AdminUnits { get; set; }
        public DbSet<AppealInfoDetail> AppealInfoDetails{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AppealInfo>(new AppealInfoDBMap());
            modelBuilder.ApplyConfiguration<TKDSIM.Entity.Entity.Enum>(new EnumDBMap());
            modelBuilder.ApplyConfiguration<EnumValue>(new EnumValueDBMap());
            modelBuilder.ApplyConfiguration<Logger>(new LoggerDbMap());
            modelBuilder.ApplyConfiguration<MissingDocs>(new MissingDocsDBMap());
            modelBuilder.ApplyConfiguration<OrderProject>(new OrderProjectDBMap());
            modelBuilder.ApplyConfiguration<SubmittedDocs>(new SubmittedDocsDBMap());
            modelBuilder.ApplyConfiguration<User>(new UserDBMap());
            modelBuilder.ApplyConfiguration<WorkDoneForm>(new WorkDoneFormDBMap());
            modelBuilder.ApplyConfiguration<WorkDoneTable>(new WorkDoneTableDBMap());
            modelBuilder.ApplyConfiguration<AdminUnit>(new AdminUnitDBMap());
            modelBuilder.ApplyConfiguration<AppealInfoDetail>(new AppealInfoDetailDBMap());
        }
    }
}
