﻿// <auto-generated />
using System;
using CustomerServiceLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerServiceLibrary.Migrations
{
    [DbContext(typeof(CustomerServiceContext))]
    [Migration("20240427160122_Seed[CustomerServiceDatabase]Tables")]
    partial class SeedCustomerServiceDatabaseTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerServiceLibrary.Models.CallLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CallLogDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Complain")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long?>("CustomerServiceOfficeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerServiceOfficeId");

                    b.ToTable("CallLogs");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("customerServiceOfficeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("customerServiceOfficeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.CustomerServiceOffice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("customerServiceOffices");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.PayHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AmountPaid")
                        .HasColumnType("int");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("PayHistory");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Wage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("HourlyPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Wages");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.WorkHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<DateTime>("WorkedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkHistory");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Worker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CustomerServiceOfficeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long?>("WageId")
                        .HasColumnType("bigint");

                    b.Property<int>("WeeklyWorkingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerServiceOfficeId");

                    b.HasIndex("WageId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.CallLog", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.CustomerServiceOffice", null)
                        .WithMany("CallLog")
                        .HasForeignKey("CustomerServiceOfficeId");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Customer", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.CustomerServiceOffice", "CustomerServiceOffice")
                        .WithMany("CustomerList")
                        .HasForeignKey("customerServiceOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerServiceOffice");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.CustomerServiceOffice", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.Company", "Company")
                        .WithMany("Office")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.PayHistory", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.WorkHistory", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.Worker", "Worker")
                        .WithMany("WorkHistory")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Worker", b =>
                {
                    b.HasOne("CustomerServiceLibrary.Models.CustomerServiceOffice", null)
                        .WithMany("Workers")
                        .HasForeignKey("CustomerServiceOfficeId");

                    b.HasOne("CustomerServiceLibrary.Models.Wage", "Wage")
                        .WithMany()
                        .HasForeignKey("WageId");

                    b.Navigation("Wage");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Company", b =>
                {
                    b.Navigation("Office");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.CustomerServiceOffice", b =>
                {
                    b.Navigation("CallLog");

                    b.Navigation("CustomerList");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("CustomerServiceLibrary.Models.Worker", b =>
                {
                    b.Navigation("WorkHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
