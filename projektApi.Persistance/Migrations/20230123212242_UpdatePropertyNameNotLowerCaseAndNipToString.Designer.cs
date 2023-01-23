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
    [Migration("20230123212242_UpdatePropertyNameNotLowerCaseAndNipToString")]
    partial class UpdatePropertyNameNotLowerCaseAndNipToString
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontrahentId");

                    b.ToTable("Klienci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8448),
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerBudynku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerLokalu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Ulica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kontrahenci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 1, 23, 22, 22, 41, 672, DateTimeKind.Local).AddTicks(6790),
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<int>("KontrahentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PiesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PiesId");

                    b.ToTable("Wizyty");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataWizyty = new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8733),
                            GodzinaWizyty = new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8737),
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
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

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
