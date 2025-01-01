using Microsoft.EntityFrameworkCore;

namespace HotelReservationWeb.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Manager> Managers { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Reservation> Reservations { get; set; } = null!;

    public virtual DbSet<ContactUs> ContactUs {get;set;}=null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsClient).HasColumnName("isClient");

            // One-to-one relationship between Client and User
            entity.HasOne(d => d.User)
                  .WithOne(p => p.Client)
                  .HasForeignKey<User>(u => u.ClientId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsEmployee).HasColumnName("isEmployee");

            // One-to-one relationship between Employee and User
            entity.HasOne(d => d.User)
                  .WithOne(p => p.Employee)
                  .HasForeignKey<Employee>(e => e.UserId);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsManager).HasColumnName("isManager");

            // One-to-one relationship between Manager and User
            entity.HasOne(d => d.User)
                  .WithOne(p => p.Manager)
                  .HasForeignKey<Manager>(m => m.UserId);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Nprice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Password).HasDefaultValue("");
            entity.Property(e => e.Role).HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
