using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst_EFCORE1.Models;

public partial class DbFirstEfcoreContext : DbContext
{
    public DbFirstEfcoreContext()
    {
    }

    public DbFirstEfcoreContext(DbContextOptions<DbFirstEfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PRAKASHLAPTOP\\SQLEXPRESS;initial catalog=dbFirstEFCore;Integrated Security=true;Trusted_Connection=True;Trust Server Certificate=True");
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Exam");

            entity.Property(e => e.Sub1).HasColumnName("sub1");
            entity.Property(e => e.Sub2).HasColumnName("sub2");

            entity.HasOne(d => d.RnoNavigation).WithMany()
                .HasForeignKey(d => d.Rno)
                .HasConstraintName("fk_student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Rno).HasName("PK__Student__CAF07DB5F4C3E907");

            entity.ToTable("Student");

            entity.Property(e => e.Rno).ValueGeneratedNever();
            entity.Property(e => e.Course)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
