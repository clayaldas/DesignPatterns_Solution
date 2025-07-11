﻿using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Models.Data;

public partial class SalesContext : DbContext
{
  public SalesContext()
  {
  }

  public SalesContext(DbContextOptions<SalesContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Category> Categories { get; set; }

  public virtual DbSet<Client> Clients { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  { }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //=> optionsBuilder.UseSqlServer("Server=XPS\\SQLEXPRESS; Database=Sales; Trusted_Connection=True; TrustServerCertificate=True;");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>(entity =>
    {
      entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Name)
              .HasMaxLength(50)
              .IsUnicode(false);
    });

    modelBuilder.Entity<Client>(entity =>
    {
      entity.Property(e => e.LastName)
              .HasMaxLength(50)
              .IsUnicode(false);
      entity.Property(e => e.Name)
              .HasMaxLength(50)
              .IsUnicode(false);
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.Property(e => e.Name)
              .HasMaxLength(50)
              .IsUnicode(false);
      entity.Property(e => e.UnitPrice).HasColumnType("numeric(5, 2)");

      entity.HasOne(d => d.Category).WithMany(p => p.Products)
              .HasForeignKey(d => d.CategoryId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Products_Categories");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
