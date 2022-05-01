﻿// <auto-generated />
using System;
using API_MySIRH.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_MySIRH.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220421213026_AddCVUrlCandidat")]
    partial class AddCVUrlCandidat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("API_MySIRH.Entities.Candidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CVUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Civilite")
                        .HasColumnType("TEXT");

                    b.Property<string>("Commentaire")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DatePremiereExperience")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmploiEncore")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<int>("PosteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosteNiveauId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PropositionSalariale")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResidenceActuelle")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("SalaireActuel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PosteId");

                    b.HasIndex("PosteNiveauId");

                    b.ToTable("Candidats");
                });

            modelBuilder.Entity("API_MySIRH.Entities.Collaborateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Civilite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDebutStage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateEntreeSqli")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DatePremiereExperience")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateSortieSqli")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diplomes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModeRecrutement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Collaborateurs");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.Civilite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Civilites");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.Poste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Postes");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.PosteNiveau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Niveaux");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.SkillCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SkillCenters");
                });

            modelBuilder.Entity("API_MySIRH.Entities.MDM.TypeContrat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TypeContrats");
                });

            modelBuilder.Entity("API_MySIRH.Entities.Memo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Memos");
                });

            modelBuilder.Entity("API_MySIRH.Entities.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordre")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Statut")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ToDoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("API_MySIRH.Entities.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordre")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("API_MySIRH.Entities.Candidat", b =>
                {
                    b.HasOne("API_MySIRH.Entities.MDM.Poste", "Poste")
                        .WithMany()
                        .HasForeignKey("PosteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_MySIRH.Entities.MDM.PosteNiveau", "Niveau")
                        .WithMany()
                        .HasForeignKey("PosteNiveauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Niveau");

                    b.Navigation("Poste");
                });

            modelBuilder.Entity("API_MySIRH.Entities.ToDoItem", b =>
                {
                    b.HasOne("API_MySIRH.Entities.ToDoList", "ToDoList")
                        .WithMany("ToDoItemList")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoList");
                });

            modelBuilder.Entity("API_MySIRH.Entities.ToDoList", b =>
                {
                    b.Navigation("ToDoItemList");
                });
#pragma warning restore 612, 618
        }
    }
}
