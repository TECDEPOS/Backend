﻿// <auto-generated />
using System;
using DEP.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEP.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240402123857_databaseContextUpdate")]
    partial class databaseContextUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEP.Repository.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DEP.Repository.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CourseType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DEP.Repository.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DEP.Repository.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileTagId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FileId");

                    b.HasIndex("FileTagId");

                    b.HasIndex("PersonId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DEP.Repository.Models.FileTag", b =>
                {
                    b.Property<int>("FileTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileTagId"));

                    b.Property<bool>("ControllerVisibility")
                        .HasColumnType("bit");

                    b.Property<bool>("DKVisibility")
                        .HasColumnType("bit");

                    b.Property<bool>("EducationBossVisibility")
                        .HasColumnType("bit");

                    b.Property<bool>("EducationLeaderVisibility")
                        .HasColumnType("bit");

                    b.Property<bool>("HRVisibility")
                        .HasColumnType("bit");

                    b.Property<bool>("PKVisibility")
                        .HasColumnType("bit");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileTagId");

                    b.ToTable("FileTags");
                });

            modelBuilder.Entity("DEP.Repository.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DEP.Repository.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("DEP.Repository.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EducationalConsultantId")
                        .HasColumnType("int");

                    b.Property<int?>("EducationalLeaderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OperationCoordinatorId")
                        .HasColumnType("int");

                    b.Property<bool>("SvuApplied")
                        .HasColumnType("bit");

                    b.Property<bool>("SvuEligible")
                        .HasColumnType("bit");

                    b.HasKey("PersonId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EducationalConsultantId");

                    b.HasIndex("EducationalLeaderId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OperationCoordinatorId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DEP.Repository.Models.PersonCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonCourses");
                });

            modelBuilder.Entity("DEP.Repository.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EducationBossId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EducationBossId");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Administrator",
                            PasswordExpiryDate = new DateTime(2024, 4, 1, 14, 38, 57, 380, DateTimeKind.Local).AddTicks(4087),
                            PasswordHash = new byte[] { 252, 99, 40, 247, 183, 57, 66, 42, 61, 21, 252, 64, 69, 230, 97, 50, 187, 92, 47, 254, 76, 6, 47, 112, 20, 192, 156, 255, 243, 3, 142, 172, 67, 173, 39, 249, 234, 34, 148, 55, 10, 56, 201, 31, 110, 27, 18, 252, 174, 53, 41, 130, 23, 99, 184, 42, 228, 246, 101, 111, 116, 247, 0, 63 },
                            PasswordSalt = new byte[] { 251, 77, 5, 47, 32, 6, 85, 104, 14, 94, 40, 49, 32, 40, 117, 99, 214, 89, 25, 22, 186, 8, 220, 247, 177, 22, 86, 3, 2, 54, 218, 246, 69, 35, 98, 238, 77, 98, 246, 103, 171, 193, 195, 226, 128, 72, 42, 48, 246, 154, 96, 45, 70, 51, 129, 97, 53, 103, 188, 199, 69, 213, 164, 178, 201, 227, 49, 19, 132, 105, 232, 138, 64, 167, 193, 204, 173, 118, 160, 182, 24, 157, 134, 142, 102, 248, 61, 170, 81, 236, 81, 206, 254, 162, 75, 182, 191, 15, 91, 43, 130, 167, 189, 127, 18, 67, 85, 76, 219, 255, 185, 92, 230, 255, 121, 130, 234, 30, 93, 255, 92, 31, 60, 23, 29, 135, 165, 46 },
                            RefreshTokenExpiryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "admin",
                            UserRole = 0
                        });
                });

            modelBuilder.Entity("DEP.Repository.Models.Book", b =>
                {
                    b.HasOne("DEP.Repository.Models.Module", "Module")
                        .WithMany("Books")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("DEP.Repository.Models.Course", b =>
                {
                    b.HasOne("DEP.Repository.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("DEP.Repository.Models.File", b =>
                {
                    b.HasOne("DEP.Repository.Models.FileTag", "FileTag")
                        .WithMany()
                        .HasForeignKey("FileTagId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DEP.Repository.Models.Person", "Person")
                        .WithMany("Files")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileTag");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DEP.Repository.Models.Person", b =>
                {
                    b.HasOne("DEP.Repository.Models.Department", "Department")
                        .WithMany("Persons")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DEP.Repository.Models.User", "EducationalConsultant")
                        .WithMany("EducationalConsultantPersons")
                        .HasForeignKey("EducationalConsultantId");

                    b.HasOne("DEP.Repository.Models.User", "EducationalLeader")
                        .WithMany("EducationLeaderPersons")
                        .HasForeignKey("EducationalLeaderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DEP.Repository.Models.Location", "Location")
                        .WithMany("Persons")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DEP.Repository.Models.User", "OperationCoordinator")
                        .WithMany("OperationCoordinatorPersons")
                        .HasForeignKey("OperationCoordinatorId");

                    b.Navigation("Department");

                    b.Navigation("EducationalConsultant");

                    b.Navigation("EducationalLeader");

                    b.Navigation("Location");

                    b.Navigation("OperationCoordinator");
                });

            modelBuilder.Entity("DEP.Repository.Models.PersonCourse", b =>
                {
                    b.HasOne("DEP.Repository.Models.Course", "Course")
                        .WithMany("PersonCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEP.Repository.Models.Person", "Person")
                        .WithMany("PersonCourses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DEP.Repository.Models.User", b =>
                {
                    b.HasOne("DEP.Repository.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DEP.Repository.Models.User", "EducationBoss")
                        .WithMany("EducationLeaders")
                        .HasForeignKey("EducationBossId");

                    b.HasOne("DEP.Repository.Models.Location", "Location")
                        .WithMany("Users")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");

                    b.Navigation("EducationBoss");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DEP.Repository.Models.Course", b =>
                {
                    b.Navigation("PersonCourses");
                });

            modelBuilder.Entity("DEP.Repository.Models.Department", b =>
                {
                    b.Navigation("Persons");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DEP.Repository.Models.Location", b =>
                {
                    b.Navigation("Persons");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DEP.Repository.Models.Module", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DEP.Repository.Models.Person", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("PersonCourses");
                });

            modelBuilder.Entity("DEP.Repository.Models.User", b =>
                {
                    b.Navigation("EducationLeaderPersons");

                    b.Navigation("EducationLeaders");

                    b.Navigation("EducationalConsultantPersons");

                    b.Navigation("OperationCoordinatorPersons");
                });
#pragma warning restore 612, 618
        }
    }
}