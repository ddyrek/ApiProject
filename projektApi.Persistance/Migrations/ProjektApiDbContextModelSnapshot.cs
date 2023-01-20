﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projektApi.Persistance;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    [DbContext(typeof(ProjektApiDbContext))]
    partial class ProjektApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("Kod_Kon_Id")
                        .HasColumnType("int");

                    b.Property<int>("KontrahentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontrahentId");

                    b.ToTable("Klienci");
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

                    b.Property<string>("Nazwa_firmy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Nip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Numer_budynku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numer_lokalu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Ulica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kontrahenci");
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Pies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<int>("Klient_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Kod_Kon_Id")
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
                });

            modelBuilder.Entity("projektApi.Domain.Entities.Wizyta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_wizyty")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Godzina_wizyty")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Kwota")
                        .HasColumnType("float");

                    b.Property<long>("Opis")
                        .HasColumnType("bigint");

                    b.Property<int>("PiesId")
                        .HasColumnType("int");

                    b.Property<int>("Pies_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PiesId");

                    b.ToTable("Wizyty");
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
