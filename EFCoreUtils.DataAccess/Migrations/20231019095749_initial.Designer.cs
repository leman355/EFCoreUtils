﻿// <auto-generated />
using EFCoreUtils.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCoreUtils.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231019095749_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFCoreUtils.Entities.MusicBand", b =>
                {
                    b.Property<int>("MusicBandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MusicBandId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MusicBandId");

                    b.ToTable("MusicBands");
                });

            modelBuilder.Entity("EFCoreUtils.Entities.Musician", b =>
                {
                    b.Property<int>("MusicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MusicianId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MusicBandId")
                        .HasColumnType("integer");

                    b.Property<string>("MusicianRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MusicianId");

                    b.HasIndex("MusicBandId");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("EFCoreUtils.Entities.Musician", b =>
                {
                    b.HasOne("EFCoreUtils.Entities.MusicBand", "MusicBand")
                        .WithMany("Musicians")
                        .HasForeignKey("MusicBandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicBand");
                });

            modelBuilder.Entity("EFCoreUtils.Entities.MusicBand", b =>
                {
                    b.Navigation("Musicians");
                });
#pragma warning restore 612, 618
        }
    }
}
