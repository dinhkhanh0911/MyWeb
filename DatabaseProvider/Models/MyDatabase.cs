using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseProvider.Models
{
    public partial class MyDatabase : DbContext
    {
        public MyDatabase()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<HocPhan> HocPhans { get; set; }
        public virtual DbSet<HocPhanNgoaiTao> HocPhanNgoaiTaos { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<TheTu> TheTus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HocPhan>()
                .HasMany(e => e.HocPhanNgoaiTaos)
                .WithRequired(e => e.HocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocPhan>()
                .HasMany(e => e.TheTus)
                .WithRequired(e => e.HocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.codeShare)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.HocSinhs)
                .WithRequired(e => e.LopHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheTu>()
                .Property(e => e.engWord)
                .IsUnicode(false);

            modelBuilder.Entity<TheTu>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<TheTu>()
                .Property(e => e.example)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HocPhans)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HocPhanNgoaiTaos)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HocSinhs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
