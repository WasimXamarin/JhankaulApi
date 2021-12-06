using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class JhankaulContext : DbContext
    {
        public JhankaulContext()
        {
        }

        public JhankaulContext(DbContextOptions<JhankaulContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAbout> TblAbouts { get; set; }
        public virtual DbSet<TblChiefGuest> TblChiefGuests { get; set; }
        public virtual DbSet<TblHome> TblHomes { get; set; }
        public virtual DbSet<TblOrganizer> TblOrganizers { get; set; }
        public virtual DbSet<TblPrize> TblPrizes { get; set; }
        public virtual DbSet<TblSainik> TblSainiks { get; set; }
        public virtual DbSet<TblSchool> TblSchools { get; set; }
        public virtual DbSet<TblSignUp> TblSignUps { get; set; }
        public virtual DbSet<TblSignUpMobile> TblSignUpMobiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Jhankaul;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAbout>(entity =>
            {
                entity.ToTable("tblAbout");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Qualification).HasMaxLength(20);

                entity.Property(e => e.Village).HasMaxLength(100);
            });

            modelBuilder.Entity<TblChiefGuest>(entity =>
            {
                entity.ToTable("tblChiefGuest");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IsVisibleData).HasDefaultValueSql("((1))");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(100);
            });

            modelBuilder.Entity<TblHome>(entity =>
            {
                entity.ToTable("tblHome");

                entity.Property(e => e.NumberOfFemale).HasMaxLength(10);

                entity.Property(e => e.NumberOfMale).HasMaxLength(10);
            });

            modelBuilder.Entity<TblOrganizer>(entity =>
            {
                entity.ToTable("tblOrganizer");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IsVisibleData).HasDefaultValueSql("((1))");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(100);
            });

            modelBuilder.Entity<TblPrize>(entity =>
            {
                entity.ToTable("tblPrize");

                entity.Property(e => e.PrizeClass).HasMaxLength(5);

                entity.Property(e => e.PrizeDescription).HasMaxLength(100);

                entity.Property(e => e.PrizeName).HasMaxLength(50);

                entity.Property(e => e.PrizePosition).HasMaxLength(5);

                entity.Property(e => e.Year).HasMaxLength(100);
            });

            modelBuilder.Entity<TblSainik>(entity =>
            {
                entity.ToTable("tblSainik");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Village).HasMaxLength(100);

                entity.Property(e => e.YearFrom).HasMaxLength(100);

                entity.Property(e => e.YearTo).HasMaxLength(100);
            });

            modelBuilder.Entity<TblSchool>(entity =>
            {
                entity.ToTable("tblSchool");

                entity.Property(e => e.AddressLineOne).HasMaxLength(50);

                entity.Property(e => e.AddressLineThree).HasMaxLength(50);

                entity.Property(e => e.AddressLineTwo).HasMaxLength(50);

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.HelpLineNumberOne).HasMaxLength(20);

                entity.Property(e => e.HelpLineNumberTwo).HasMaxLength(20);

                entity.Property(e => e.NumberOfBoy).HasMaxLength(10);

                entity.Property(e => e.NumberOfBus).HasMaxLength(10);

                entity.Property(e => e.NumberOfGirl).HasMaxLength(10);

                entity.Property(e => e.NumberOfStudent).HasMaxLength(10);

                entity.Property(e => e.NumberOfTeacherFemale).HasMaxLength(10);

                entity.Property(e => e.NumberOfTeacherMale).HasMaxLength(10);

                entity.Property(e => e.PrincipleName).HasMaxLength(200);

                entity.Property(e => e.SchoolName).HasMaxLength(200);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.YearFrom).HasMaxLength(10);
            });

            modelBuilder.Entity<TblSignUp>(entity =>
            {
                entity.ToTable("tblSignUp");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSignUpMobile>(entity =>
            {
                entity.ToTable("tblSignUpMobile");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
