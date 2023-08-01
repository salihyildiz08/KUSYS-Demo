using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class EditCourseTest
    {
        private readonly ICourseService _CourseService;
        private readonly Mock<IRepositoryDal<Course>> _mockCourseRepository;

        public EditCourseTest()
        {
            // Test ama�l� repository'nin Mock halini olu�tur
            _mockCourseRepository = new Mock<IRepositoryDal<Course>>();
            _CourseService = new CourseManager(_mockCourseRepository.Object);
        }

        [Fact]
        public void EditCourseTesti()
        {
            // Haz�rl�k (Arrange)
            int courseId = 1;
            string code = "SYY101";
            string ad = "Sy�lsalll";

            // Mock repository'den ��renci verisini al�p d�zenleme yapmak i�in ayarla
            _mockCourseRepository.Setup(repo => repo.GetById(courseId)).Returns(new Course
            {
                CourseId = courseId,
                CourseCode = "Eski code", // Mevcut code
                CourseName = "Eski ad" // Mevcut ad
            });

            // Act
            var course = _CourseService.TGetById(courseId);
            course.CourseName = ad;
            course.CourseCode = code;
            _CourseService.TUpdate(course);

            // Do�rulama (Assert)
            // Repository'nin Update metodunun beklenen ��renci nesnesiyle �a�r�ld���n� do�rula
            _mockCourseRepository.Verify(repo => repo.Update(It.Is<Course>(updatedCourse =>
                updatedCourse.CourseId == courseId &&
                updatedCourse.CourseCode == code &&
                updatedCourse.CourseName == ad
            )), Times.Once);
        }
    }
}
