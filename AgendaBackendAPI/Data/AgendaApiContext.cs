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
        public DbSet<Contact> Contactos { get; set; }
        public DbSet<Location> Locations { get; set; }

        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User Erica = new User()
            {
                id = 1,
                email = "prueba123@gmail.com",
                password = "password",
                name = "brenda",
                Rol = Rol.Admin,
            };

            User Dana = new User()
            {
                id = 2,
                email = "prueba123@gmail.com",
                password = "password",
                name = "name",
                Rol = Rol.Admin


            };
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

            base.OnModelCreating(modelBuilder);
        }


    }
}

