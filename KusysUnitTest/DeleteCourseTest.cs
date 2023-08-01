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
            // Test ama�l� repository'nin Mock halini olu�tur
            _mockCourseRepository = new Mock<IRepositoryDal<Course>>();
            _CourseService = new CourseManager(_mockCourseRepository.Object);
        }

        [Fact]
        public void DeleteCourseTesti()
        {
            // Haz�rl�k (Arrange)
            int courseId = 1;

            // Mock repository'den ��renci verisini al�p silme i�lemi yapmak i�in ayarla
            _mockCourseRepository.Setup(repo => repo.GetById(courseId)).Returns(new Course
            {
                CourseId = courseId
            });

            // Act
            var ogrenci = _CourseService.TGetById(courseId);
            _CourseService.TDelete(ogrenci);

            // Do�rulama (Assert)
            // Repository'nin Delete metodunun beklenen ��renci nesnesiyle �a�r�ld���n� do�rula
            _mockCourseRepository.Verify(repo => repo.Delete(It.Is<Course>(deletedCourse =>
                deletedCourse.CourseId == courseId
            )), Times.Once);
        }
    }
}
