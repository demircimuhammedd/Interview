﻿// <auto-generated />
using System;
using Interview.Infrastructure.Persistence.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Interview.Infrastructure.Persistence.EfCore.Migrations
{
    [DbContext(typeof(InterviewContext))]
    partial class InterviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FringeBenefitJob", b =>
                {
                    b.Property<Guid>("FringeBenefitID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("JobsID")
                        .HasColumnType("uuid");

                    b.HasKey("FringeBenefitID", "JobsID");

                    b.HasIndex("JobsID");

                    b.ToTable("FringeBenefitJob");
                });

            modelBuilder.Entity("Interview.Domain.Entities.BadVocable", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("BadVocables");
                });

            modelBuilder.Entity("Interview.Domain.Entities.FringeBenefit", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("FringeBenefits");
                });

            modelBuilder.Entity("Interview.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("FringeBenefitId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<short>("Rate")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("WorkTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("CreatedById");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Interview.Domain.Entities.Position", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Interview.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("JobQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Interview.Domain.Entities.WorkType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("JobPosition", b =>
                {
                    b.Property<Guid>("JobsID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PositionsID")
                        .HasColumnType("uuid");

                    b.HasKey("JobsID", "PositionsID");

                    b.HasIndex("PositionsID");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("JobWorkType", b =>
                {
                    b.Property<Guid>("JobsID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkTypeID")
                        .HasColumnType("uuid");

                    b.HasKey("JobsID", "WorkTypeID");

                    b.HasIndex("WorkTypeID");

                    b.ToTable("JobWorkType");
                });

            modelBuilder.Entity("FringeBenefitJob", b =>
                {
                    b.HasOne("Interview.Domain.Entities.FringeBenefit", null)
                        .WithMany()
                        .HasForeignKey("FringeBenefitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interview.Domain.Entities.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interview.Domain.Entities.Job", b =>
                {
                    b.HasOne("Interview.Domain.Entities.User", "CreatedBy")
                        .WithMany("Jobs")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("JobPosition", b =>
                {
                    b.HasOne("Interview.Domain.Entities.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interview.Domain.Entities.Position", null)
                        .WithMany()
                        .HasForeignKey("PositionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobWorkType", b =>
                {
                    b.HasOne("Interview.Domain.Entities.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interview.Domain.Entities.WorkType", null)
                        .WithMany()
                        .HasForeignKey("WorkTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Interview.Domain.Entities.User", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}