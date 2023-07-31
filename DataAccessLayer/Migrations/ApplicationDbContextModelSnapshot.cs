﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseCode = "CSI101",
                            CourseName = "Introduction to Computer Science"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseCode = "CSI102",
                            CourseName = "Algorithms"
                        },
                        new
                        {
                            CourseId = 3,
                            CourseCode = "MAT101",
                            CourseName = "Calculus"
                        },
                        new
                        {
                            CourseId = 4,
                            CourseCode = "PHY101",
                            CourseName = "Physics"
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BirthDate = new DateTime(1996, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Salih",
                            LastName = "Yıldız"
                        },
                        new
                        {
                            StudentId = 2,
                            BirthDate = new DateTime(1985, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Adil",
                            LastName = "Yılmaz"
                        },
                        new
                        {
                            StudentId = 3,
                            BirthDate = new DateTime(1974, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Yelda",
                            LastName = "Geçer"
                        },
                        new
                        {
                            StudentId = 4,
                            BirthDate = new DateTime(2008, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sümmeye",
                            LastName = "Kara"
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCourseId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentCourseId = 1,
                            CourseId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 2,
                            CourseId = 2,
                            StudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 3,
                            CourseId = 3,
                            StudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 4,
                            CourseId = 4,
                            StudentId = 1
                        },
                        new
                        {
                            StudentCourseId = 5,
                            CourseId = 1,
                            StudentId = 2
                        },
                        new
                        {
                            StudentCourseId = 6,
                            CourseId = 2,
                            StudentId = 2
                        },
                        new
                        {
                            StudentCourseId = 7,
                            CourseId = 3,
                            StudentId = 2
                        },
                        new
                        {
                            StudentCourseId = 8,
                            CourseId = 1,
                            StudentId = 3
                        },
                        new
                        {
                            StudentCourseId = 9,
                            CourseId = 2,
                            StudentId = 3
                        },
                        new
                        {
                            StudentCourseId = 10,
                            CourseId = 1,
                            StudentId = 4
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.StudentCourse", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
