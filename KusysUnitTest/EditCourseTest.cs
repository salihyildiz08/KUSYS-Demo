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
            // Test amaçlý repository'nin Mock halini oluþtur
            _mockCourseRepository = new Mock<IRepositoryDal<Course>>();
            _CourseService = new CourseManager(_mockCourseRepository.Object);
        }

        [Fact]
        public void EditCourseTesti()
        {
            // Hazýrlýk (Arrange)
            int courseId = 1;
            string code = "SYY101";
            string ad = "Syýlsalll";

            // Mock repository'den öðrenci verisini alýp düzenleme yapmak için ayarla
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

            // Doðrulama (Assert)
            // Repository'nin Update metodunun beklenen öðrenci nesnesiyle çaðrýldýðýný doðrula
            _mockCourseRepository.Verify(repo => repo.Update(It.Is<Course>(updatedCourse =>
                updatedCourse.CourseId == courseId &&
                updatedCourse.CourseCode == code &&
                updatedCourse.CourseName == ad
            )), Times.Once);
        }
    }
}
