﻿// <auto-generated />
using System;
using AgendaBackendAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaBackendAPI.Migrations
{
    [DbContext(typeof(AgendaApiContext))]
    partial class AgendaApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("AgendaBackendAPI.Entities.Contact", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("celularNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("telephoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.Location", b =>
                {
                    b.Property<int?>("id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("longitude")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("state")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Rol = 0,
                            email = "prueba@gmail.com",
                            lastName = "Usuario1",
                            name = "Usuario1",
                            password = "password",
                            state = 0
                        });
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.Contact", b =>
                {
                    b.HasOne("AgendaBackendAPI.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.Location", b =>
                {
                    b.HasOne("AgendaBackendAPI.Entities.Contact", null)
                        .WithOne("location")
                        .HasForeignKey("AgendaBackendAPI.Entities.Location", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.Contact", b =>
                {
                    b.Navigation("location")
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaBackendAPI.Entities.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
