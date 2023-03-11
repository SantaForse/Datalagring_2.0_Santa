using System;
using System.Collections.Generic;
using Final_Santa.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final_Santa.Contexts;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Errand> Errands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jespe\\Desktop\\Final.Santa\\Final_Santa\\Final_Santa\\Contexts\\sql_db.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07AE57DF05");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105347ECC7E03").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Errand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Errands__3214EC073AC77376");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ErrandDate).HasColumnType("date");
            entity.Property(e => e.ErrandDescription).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Errands)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Errands__Custome__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
