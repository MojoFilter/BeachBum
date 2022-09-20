﻿// <auto-generated />
using System;
using BeachBumService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeachBumService.Migrations
{
    [DbContext(typeof(BeachBumContext))]
    [Migration("20220920031041_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeachBum.Core.BonusAnswer", b =>
                {
                    b.Property<int>("BonusAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BonusAnswerId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionBonusQuestionId")
                        .HasColumnType("int");

                    b.HasKey("BonusAnswerId");

                    b.HasIndex("QuestionBonusQuestionId");

                    b.ToTable("BonusAnswers");
                });

            modelBuilder.Entity("BeachBum.Core.BonusQuestion", b =>
                {
                    b.Property<int>("BonusQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BonusQuestionId"), 1L, 1);

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BonusQuestionId");

                    b.ToTable("BonusQuestions");
                });

            modelBuilder.Entity("BeachBum.Core.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Schedule")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("VenueId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BeachBum.Core.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("BeachBum.Core.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoundId"), 1L, 1);

                    b.Property<int?>("BonusQuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("BonusQuestionId");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BeachBum.Core.RoundQuestion", b =>
                {
                    b.Property<int>("RoundQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoundQuestionId"), 1L, 1);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.HasKey("RoundQuestionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("RoundId");

                    b.ToTable("RoundQuestions");
                });

            modelBuilder.Entity("BeachBum.Core.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VenueId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VenueId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("BeachBum.Core.BonusAnswer", b =>
                {
                    b.HasOne("BeachBum.Core.BonusQuestion", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionBonusQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("BeachBum.Core.Game", b =>
                {
                    b.HasOne("BeachBum.Core.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("BeachBum.Core.Round", b =>
                {
                    b.HasOne("BeachBum.Core.BonusQuestion", "BonusQuestion")
                        .WithMany()
                        .HasForeignKey("BonusQuestionId");

                    b.HasOne("BeachBum.Core.Game", null)
                        .WithMany("Rounds")
                        .HasForeignKey("GameId");

                    b.Navigation("BonusQuestion");
                });

            modelBuilder.Entity("BeachBum.Core.RoundQuestion", b =>
                {
                    b.HasOne("BeachBum.Core.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeachBum.Core.Round", "Round")
                        .WithMany("Questions")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("BeachBum.Core.BonusQuestion", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("BeachBum.Core.Game", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("BeachBum.Core.Round", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
