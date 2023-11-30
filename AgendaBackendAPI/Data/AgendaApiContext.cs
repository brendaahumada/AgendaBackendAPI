using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AgendaBackendAPI.Data
{
    public class AgendaApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Location { get; set; }

        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.location)
                .WithOne()
                .HasForeignKey<Location>(l => l.id)
                .OnDelete(DeleteBehavior.Cascade);

            // Agregar usuarios hardcoded
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 1,
                    name = "Usuario1",
                    lastName = "Usuario1",
                    email = "prueba@gmail.com",
                    password = "password",
                    Rol = Rol.Admin,
                    state = State.Active
                });

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    id = 1,
                    UserId = 1,
                    name = "brenda",
                });

            base.OnModelCreating(modelBuilder);
        }



    }
}

