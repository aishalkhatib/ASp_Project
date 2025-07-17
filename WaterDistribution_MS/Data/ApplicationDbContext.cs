using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WaterDistribution_MS.Models;

namespace WaterDistribution_MS.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Tank> Tanks { get; set; }

    public virtual DbSet<TankArea> TankAreas { get; set; }

    public virtual DbSet<VwOrderDetail> VwOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-68S8SU9;Database=Suqia_Db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82048C9A57C37");

            entity.Property(e => e.AreaName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D84DD34BA3");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Area).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__Customers__AreaI__398D8EEE");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Deliveri__626D8FCE05BFF749");

            entity.Property(e => e.DeliveryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(300);

            entity.HasOne(d => d.Driver).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Deliverie__Drive__4BAC3F29");

            entity.HasOne(d => d.Order).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Deliverie__Order__4AB81AF0");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__F1B1CD0471EA2195");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF81DADA3C");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("بانتظار القبول");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__4316F928");

            entity.HasOne(d => d.Tank).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TankId)
                .HasConstraintName("FK__Orders__TankId__440B1D61");
        });

        modelBuilder.Entity<Tank>(entity =>
        {
            entity.HasKey(e => e.TankId).HasName("PK__Tanks__97DE7065FA96857D");

            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.PricePerBarrel).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WaterType).HasMaxLength(50);
        });

        modelBuilder.Entity<TankArea>(entity =>
        {
            entity.HasKey(e => e.TankAreaId).HasName("PK__TankArea__BA874C4A4A0DAE8E");

            entity.HasOne(d => d.Area).WithMany(p => p.TankAreas)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__TankAreas__AreaI__403A8C7D");

            entity.HasOne(d => d.Tank).WithMany(p => p.TankAreas)
                .HasForeignKey(d => d.TankId)
                .HasConstraintName("FK__TankAreas__TankI__3F466844");
        });

        modelBuilder.Entity<VwOrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_OrderDetails");

            entity.Property(e => e.AreaName).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PricePerBarrel).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TankLocation).HasMaxLength(200);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(21, 2)");
            entity.Property(e => e.WaterType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
