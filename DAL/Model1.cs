namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=SEICBalance")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<BGroups> BGroups { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<v_BGroups> v_BGroups { get; set; }
        public virtual DbSet<SEIC_v_MappingITEH> SEIC_v_MappingITEH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BGroups>()
                .Property(e => e.BGroupName)
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

            modelBuilder.Entity<v_BGroups>()
                .Property(e => e.BGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<SEIC_v_MappingITEH>()
                .Property(e => e.LSName)
                .IsUnicode(false);

            modelBuilder.Entity<SEIC_v_MappingITEH>()
                .Property(e => e.DBName)
                .IsUnicode(false);

            modelBuilder.Entity<SEIC_v_MappingITEH>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<SEIC_v_MappingITEH>()
                .Property(e => e.TagName)
                .IsUnicode(false);
        }
    }
}
