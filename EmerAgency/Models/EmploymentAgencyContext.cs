using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmerAgency.Models;

public partial class EmploymentAgencyContext : DbContext
{
    public EmploymentAgencyContext()
    {
    }

    public EmploymentAgencyContext(DbContextOptions<EmploymentAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activitytype> Activitytypes { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Jobseeker> Jobseekers { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=sel;password=12345;database=employment_agency", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Activitytype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("activitytypes");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.DealId).HasName("PRIMARY");

            entity.ToTable("deals");

            entity.HasIndex(e => e.EmployerId, "EmployerID");

            entity.HasIndex(e => e.JobSeekerId, "JobSeekerID");

            entity.Property(e => e.DealId).HasColumnName("DealID");
            entity.Property(e => e.Commission).HasPrecision(10, 2);
            entity.Property(e => e.EmployerId).HasColumnName("EmployerID");
            entity.Property(e => e.JobSeekerId).HasColumnName("JobSeekerID");
            entity.Property(e => e.Position).HasMaxLength(255);

            entity.HasOne(d => d.Employer).WithMany(p => p.Deals)
                .HasForeignKey(d => d.EmployerId)
                .HasConstraintName("deals_ibfk_2");

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.Deals)
                .HasForeignKey(d => d.JobSeekerId)
                .HasConstraintName("deals_ibfk_1");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerId).HasName("PRIMARY");

            entity.ToTable("employers");

            entity.Property(e => e.EmployerId).HasColumnName("EmployerID");
            entity.Property(e => e.ActivityType).HasMaxLength(255);
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Jobseeker>(entity =>
        {
            entity.HasKey(e => e.JobSeekerId).HasName("PRIMARY");

            entity.ToTable("jobseekers");

            entity.Property(e => e.JobSeekerId).HasColumnName("JobSeekerID");
            entity.Property(e => e.ActivityType).HasMaxLength(255);
            entity.Property(e => e.ExpectedSalary).HasPrecision(10, 2);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.OtherData).HasColumnType("text");
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.Qualification).HasMaxLength(255);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.VacancyId).HasName("PRIMARY");

            entity.ToTable("vacancies");

            entity.HasIndex(e => e.EmployerId, "EmployerID");

            entity.HasIndex(e => e.TypeId, "TypeID");

            entity.Property(e => e.VacancyId).HasColumnName("VacancyID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EmployerId).HasColumnName("EmployerID");
            entity.Property(e => e.StartingSalary).HasPrecision(10, 2);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Employer).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.EmployerId)
                .HasConstraintName("vacancies_ibfk_1");

            entity.HasOne(d => d.Type).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("vacancies_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
