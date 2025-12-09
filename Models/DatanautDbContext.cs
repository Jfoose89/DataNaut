using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

public partial class DatanautDbContext : DbContext
{
    public DatanautDbContext()
    {
    }

    public DatanautDbContext(DbContextOptions<DatanautDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectManager> ProjectManagers { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<TimeLog> TimeLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DatanautDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.PkprojectId).HasName("PK__Project__1A1F05A2F3261658");

            entity.HasOne(d => d.FkprojectManager).WithMany(p => p.Projects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_ProjectManager");
        });

        modelBuilder.Entity<ProjectManager>(entity =>
        {
            entity.HasKey(e => e.PkprojectManagerId).HasName("PK__ProjectM__AE6D6ACEB67AB191");

            entity.HasOne(d => d.Fkrole).WithMany(p => p.ProjectManagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectManager_Role");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.PkreportId).HasName("PK__Report__BFF8F6AE38A425C4");

            entity.HasOne(d => d.Fkproject).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_Project");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.PkresourceId).HasName("PK__Resource__8EF7FE5F3904FD64");

            entity.HasOne(d => d.Fkproject).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_Project");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.PkroleId).HasName("PK__Role__B962131494311597");
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => e.PkteamMemberId).HasName("PK__TeamMemb__295C6A18A67427BD");

            entity.HasOne(d => d.Fkproject).WithMany(p => p.TeamMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMember_Project");

            entity.HasOne(d => d.FkprojectManager).WithMany(p => p.TeamMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMember_ProjectManager");

            entity.HasOne(d => d.Fkrole).WithMany(p => p.TeamMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMember_Role");
        });

        modelBuilder.Entity<TimeLog>(entity =>
        {
            entity.HasKey(e => e.PktimeLogId).HasName("PK__TimeLog__F1CF3406FBCF09AB");

            entity.HasOne(d => d.Fkreport).WithMany(p => p.TimeLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeLog_Report");

            entity.HasOne(d => d.FkteamMember).WithMany(p => p.TimeLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeLog_TeamMember");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
