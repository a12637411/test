﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(GFContext))]
    [Migration("20240513123053_hamma")]
    partial class hamma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.ApplicationCore.Domain.Artiste", b =>
                {
                    b.Property<int>("ArtisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtisteId"), 1L, 1);

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationalite")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ArtisteId");

                    b.ToTable("Artistes");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Chanson", b =>
                {
                    b.Property<int>("ChansonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChansonId"), 1L, 1);

                    b.Property<int>("ArtisteFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("StyleMusical")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("VuesYoutube")
                        .HasColumnType("int");

                    b.HasKey("ChansonId");

                    b.HasIndex("ArtisteFk");

                    b.ToTable("Chansons");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Concert", b =>
                {
                    b.Property<DateTime>("DateConcert")
                        .HasColumnType("datetime2");

                    b.Property<int>("ArtisteFk")
                        .HasColumnType("int");

                    b.Property<int>("FestivalFk")
                        .HasColumnType("int");

                    b.Property<double>("Cachet")
                        .HasColumnType("float");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.HasKey("DateConcert", "ArtisteFk", "FestivalFk");

                    b.HasIndex("ArtisteFk");

                    b.HasIndex("FestivalFk");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Festival", b =>
                {
                    b.Property<int>("FestivalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FestivalId"), 1L, 1);

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FestivalId");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Chanson", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Artiste", "Artiste")
                        .WithMany("Chansons")
                        .HasForeignKey("ArtisteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiste");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Concert", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Artiste", "Artiste")
                        .WithMany("Concerts")
                        .HasForeignKey("ArtisteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.Domain.Festival", "Festival")
                        .WithMany("Concerts")
                        .HasForeignKey("FestivalFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artiste");

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Artiste", b =>
                {
                    b.Navigation("Chansons");

                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Festival", b =>
                {
                    b.Navigation("Concerts");
                });
#pragma warning restore 612, 618
        }
    }
}
