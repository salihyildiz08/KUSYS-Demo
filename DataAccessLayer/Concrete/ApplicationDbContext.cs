
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student Seed
            modelBuilder.Entity<Student>().HasData(
            new Student() { StudentId = 1, FirstName = "Salih", LastName = "Yıldız", BirthDate = new DateTime(1996, 09, 08) },
            new Student() { StudentId = 2, FirstName = "Adil", LastName = "Yılmaz", BirthDate = new DateTime(1985, 01, 18) },
            new Student() { StudentId = 3, FirstName = "Yelda", LastName = "Geçer", BirthDate = new DateTime(1974, 09, 30) },
            new Student() { StudentId = 4, FirstName = "Sümmeye", LastName = "Kara", BirthDate = new DateTime(2008, 07, 24) }
               );

            //Course Seed
            modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, CourseCode = "CSI101", CourseName = "Introduction to Computer Science" },
            new Course { CourseId = 2, CourseCode = "CSI102", CourseName = "Algorithms" },
            new Course { CourseId = 3, CourseCode = "MAT101", CourseName = "Calculus" },
            new Course { CourseId = 4, CourseCode = "PHY101", CourseName = "Physics" }
                );


            // Student with Course Relationship
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse() { StudentCourseId=1,CourseId=1,StudentId=1},
                new StudentCourse() { StudentCourseId=2,CourseId=2,StudentId=1},
                new StudentCourse() { StudentCourseId=3,CourseId=3,StudentId=1},
                new StudentCourse() { StudentCourseId=4,CourseId=4,StudentId=1},
                new StudentCourse() { StudentCourseId=5,CourseId=1,StudentId=2},
                new StudentCourse() { StudentCourseId=6,CourseId=2,StudentId=2},
                new StudentCourse() { StudentCourseId=7,CourseId=3,StudentId=2},
                new StudentCourse() { StudentCourseId=8,CourseId=1,StudentId=3},
                new StudentCourse() { StudentCourseId=9,CourseId=2,StudentId=3},
                new StudentCourse() { StudentCourseId=10,CourseId=1,StudentId=4}
                );
        }

    }
}
