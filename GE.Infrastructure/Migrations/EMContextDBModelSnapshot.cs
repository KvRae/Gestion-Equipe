﻿// <auto-generated />
using System;
using GE.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GE.Infrastructure.Migrations
{
    [DbContext(typeof(EMContextDB))]
    partial class EMContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GE.ApplicationCore.Domain.Contrat", b =>
                {
                    b.Property<DateTime>("DateContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<int>("MembreFK")
                        .HasColumnType("int");

                    b.Property<short>("DureeMMois")
                        .HasColumnType("smallint");

                    b.Property<double>("Salaire")
                        .HasColumnType("float");

                    b.HasKey("DateContrat", "EquipeFK", "MembreFK");

                    b.HasIndex("EquipeFK");

                    b.HasIndex("MembreFK");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipeId"), 1L, 1);

                    b.Property<string>("AdresseLocal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NomEquipe")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EquipeId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Membre", b =>
                {
                    b.Property<int>("Identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifiant"), 1L, 1);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Identifiant");

                    b.ToTable("Membres");

                    b.HasDiscriminator<string>("Type").HasValue("M");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Trophee", b =>
                {
                    b.Property<int>("TropheeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TropheeId"), 1L, 1);

                    b.Property<DateTime>("DateTrophee")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<double>("Recompense")
                        .HasColumnType("float");

                    b.HasKey("TropheeId");

                    b.HasIndex("EquipeFK");

                    b.ToTable("Trophees");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Entraineur", b =>
                {
                    b.HasBaseType("GE.ApplicationCore.Domain.Membre");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("E");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Joueur", b =>
                {
                    b.HasBaseType("GE.ApplicationCore.Domain.Membre");

                    b.Property<string>("Poste")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasDiscriminator().HasValue("J");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Contrat", b =>
                {
                    b.HasOne("GE.ApplicationCore.Domain.Equipe", "Equipe")
                        .WithMany("Contrats")
                        .HasForeignKey("EquipeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GE.ApplicationCore.Domain.Membre", "Member")
                        .WithMany("Contrats")
                        .HasForeignKey("MembreFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Trophee", b =>
                {
                    b.HasOne("GE.ApplicationCore.Domain.Equipe", "Equipe")
                        .WithMany("Trophees")
                        .HasForeignKey("EquipeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Navigation("Contrats");

                    b.Navigation("Trophees");
                });

            modelBuilder.Entity("GE.ApplicationCore.Domain.Membre", b =>
                {
                    b.Navigation("Contrats");
                });
#pragma warning restore 612, 618
        }
    }
}
