using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class DeleteCourseTest
    {
        private readonly ICourseService _CourseService;
        private readonly Mock<IRepositoryDal<Course>> _mockCourseRepository;

        public DeleteCourseTest()
        {
            // Test amaçlý repository'nin Mock halini oluþtur
            _mockCourseRepository = new Mock<IRepositoryDal<Course>>();
            _CourseService = new CourseManager(_mockCourseRepository.Object);
        }

        [Fact]
        public void DeleteCourseTesti()
        {
            // Hazýrlýk (Arrange)
            int courseId = 1;

            // Mock repository'den öðrenci verisini alýp silme iþlemi yapmak için ayarla
            _mockCourseRepository.Setup(repo => repo.GetById(courseId)).Returns(new Course
            {
                CourseId = courseId
            });

            // Act
            var ogrenci = _CourseService.TGetById(courseId);
            _CourseService.TDelete(ogrenci);

            // Doðrulama (Assert)
            // Repository'nin Delete metodunun beklenen öðrenci nesnesiyle çaðrýldýðýný doðrula
            _mockCourseRepository.Verify(repo => repo.Delete(It.Is<Course>(deletedCourse =>
                deletedCourse.CourseId == courseId
            )), Times.Once);
        }
    }
}
