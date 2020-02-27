namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ITEMDB : DbContext
    {
        public ITEMDB()
            : base("name=ITEMDB")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SEICALARMHISTORY> SEICALARMHISTORY { get; set; }
        public virtual DbSet<SEICEVENTHISTORY> SEICEVENTHISTORY { get; set; }
        public virtual DbSet<SEIC_v_TREND> SEIC_v_TREND { get; set; }
        public virtual DbSet<v_TREND002> v_TREND002 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_Tag)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_Message)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_Selection)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_User)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_User_Comment)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_User_Full)
                .IsUnicode(false);

            modelBuilder.Entity<SEICALARMHISTORY>()
                .Property(e => e.Al_Station)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Info)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_User)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_User_Full)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Message)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Value)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Prev_Value)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Station)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Comment)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.Ev_Source)
                .IsUnicode(false);

            modelBuilder.Entity<SEICEVENTHISTORY>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<SEIC_v_TREND>()
                .Property(e => e.Tagname)
                .IsUnicode(false);
        }
    }
}
