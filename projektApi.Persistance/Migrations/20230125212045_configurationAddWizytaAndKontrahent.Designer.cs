﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projektApi.Persistance;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    [DbContext(typeof(ProjektApiDbContext))]
    [Migration("20230125212045_configurationAddWizytaAndKontrahent")]
    partial class configurationAddWizytaAndKontrahent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("projektApi.Domain.Entities.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KontrahentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontrahentId");

                    b.ToTable("Klienci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7246),
                            CreatedBy = "Dawid",
                            KontrahentId = 1,
                            PhoneNumber = "+48 606327833",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Kontrahent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaFirmy")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Nip")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NumerBudynku")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("NumerLokalu")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Ulica")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Kontrahenci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7088),
                            CreatedBy = "Dawid",
                            NazwaFirmy = "Top Dogs",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Pies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<int>("KontrahentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.HasIndex("KontrahentId");

                    b.ToTable("Psy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KlientId = 1,
                            KontrahentId = 1,
                            Name = "Jackie",
                            Race = "BORDER COLLIE"
                        },
                        new
                        {
                            Id = 2,
                            KlientId = 1,
                            KontrahentId = 1,
                            Name = "Fifi",
                            Race = "BORDER TERRIER"
                        });
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Wizyta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataWizyty")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GodzinaWizyty")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Kwota")
                        .HasMaxLength(2)
                        .HasPrecision(8)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Opis")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PiesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PiesId");

                    b.ToTable("Wizyty");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataWizyty = new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7511),
                            GodzinaWizyty = new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7518),
                            Kwota = 350m,
                            Opis = "Strzyżenie",
                            PiesId = 1
                        });
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Klient", b =>
                {
                    b.HasOne("projektApi.Domain.Entities.Kontrahent", "Kontrahent")
                        .WithMany("Klienci")
                        .HasForeignKey("KontrahentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("projektApi.Domain.ValueObjects.PersonName", "KlientName", b1 =>
                        {
                            b1.Property<int>("KlientId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Name");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Surname");

                            b1.HasKey("KlientId");

                            b1.ToTable("Klienci");

                            b1.WithOwner()
                                .HasForeignKey("KlientId");

                            b1.HasData(
                                new
                                {
                                    KlientId = 1,
                                    Name = "Andrzej",
                                    Surname = "Trycz"
                                });
                        });

                    b.Navigation("KlientName")
                        .IsRequired();

                    b.Navigation("Kontrahent");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Pies", b =>
                {
                    b.HasOne("projektApi.Domain.Entities.Klient", "Klient")
                        .WithMany("Psy")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projektApi.Domain.Entities.Kontrahent", "Kontrahent")
                        .WithMany("Psy")
                        .HasForeignKey("KontrahentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("Kontrahent");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Wizyta", b =>
                {
                    b.HasOne("projektApi.Domain.Entities.Pies", "Pies")
                        .WithMany("Wizyty")
                        .HasForeignKey("PiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pies");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Klient", b =>
                {
                    b.Navigation("Psy");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Kontrahent", b =>
                {
                    b.Navigation("Klienci");

                    b.Navigation("Psy");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Pies", b =>
                {
                    b.Navigation("Wizyty");
                });
#pragma warning restore 612, 618
        }
    }
}
