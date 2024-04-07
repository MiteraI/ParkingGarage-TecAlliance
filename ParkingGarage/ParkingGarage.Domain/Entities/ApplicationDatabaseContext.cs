using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Domain.Entities
{
    public class ApplicationDatabaseContext : IdentityDbContext<
        User, Role, string,
        IdentityUserClaim<string>,
        UserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>
        >
    {
        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<Floor> Floors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");

            modelBuilder.Entity<Floor>()
                .HasMany(f => f.ParkingSlots)
                .WithOne(ps => ps.Floor)
                .HasForeignKey(ps => ps.FloorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParkingSlot>()
                .HasMany(ps => ps.Tickets)
                .WithOne(t => t.ParkingSlot)
                .HasForeignKey(t => t.ParkingSlotId);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Tickets)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.VehicleId);
        }
    }
}
