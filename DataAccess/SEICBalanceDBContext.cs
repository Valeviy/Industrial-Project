namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class SEICBalanceDBContext : DbContext
    {
        public SEICBalanceDBContext()
            : base("name=SEICBalance")
        {
        }

        public virtual DbSet<BalanceClosed> BalanceClosed { get; set; }
        public virtual DbSet<BGroups> BGroups { get; set; }
        public virtual DbSet<Periods> Periods { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Rules> Rules { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<BalanceClosed_temp> BalanceClosed_temp { get; set; }
        public virtual DbSet<ReportTypes> ReportTypes { get; set; }
        public virtual DbSet<v_BGroups> v_BGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalanceClosed>()
                .Property(e => e.BGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed>()
                .Property(e => e.PointName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed>()
                .Property(e => e.Direction)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BGroups>()
                .Property(e => e.BGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BGroups>()
                .HasMany(e => e.BGroups1)
                .WithOptional(e => e.BGroups2)
                .HasForeignKey(e => e.BGroupIDParent);

            modelBuilder.Entity<BGroups>()
                .HasMany(e => e.Points)
                .WithRequired(e => e.BGroups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Periods>()
                .Property(e => e.PeriodName)
                .IsUnicode(false);

            modelBuilder.Entity<Points>()
                .Property(e => e.Direction)
                .IsUnicode(false);

            modelBuilder.Entity<Points>()
                .Property(e => e.Tagname)
                .IsUnicode(false);

            modelBuilder.Entity<Points>()
                .Property(e => e.PointName)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.ResourceName)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.BGroups)
                .WithRequired(e => e.Resources)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rules>()
                .Property(e => e.Formula)
                .IsUnicode(false);

            modelBuilder.Entity<Sources>()
                .Property(e => e.SourceName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed_temp>()
                .Property(e => e.BGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed_temp>()
                .Property(e => e.PointName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed_temp>()
                .Property(e => e.Direction)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed_temp>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceClosed_temp>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReportTypes>()
                .Property(e => e.ReportName)
                .IsUnicode(false);

            modelBuilder.Entity<ReportTypes>()
                .Property(e => e.ReportTemplName)
                .IsUnicode(false);

            modelBuilder.Entity<v_BGroups>()
                .Property(e => e.BGroupName)
                .IsUnicode(false);
        }
    }
}
