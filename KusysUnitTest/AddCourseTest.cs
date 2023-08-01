using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class AddCourseTest
    {
        private readonly ICourseService _courseService;
        private readonly Mock<IRepositoryDal<Course>> _mockCourseRepository;

        public AddCourseTest()
        {
            // Mock the repository for testing purposes
            _mockCourseRepository = new Mock<IRepositoryDal<Course>>();
            _courseService = new CourseManager(_mockCourseRepository.Object);
        }

        [Fact]
        public void AddCourse()
        {
            // Arrange
            string courseCode = "SY101";
            string courseName = "Sayýsal";

            Course s = new Course
            {
               CourseCode = courseCode,
               CourseName = courseName
            };

            // Setup the mock repository to expect Add method call
            _mockCourseRepository.Setup(repo => repo.Add(It.IsAny<Course>()));

            // Act
            _courseService.TAdd(s);

            // Assert
            // Verify that the Add method of the repository was called with the expected student object
            _mockCourseRepository.Verify(repo => repo.Add(It.Is<Course>(course =>
                course.CourseCode==courseCode &&
                course.CourseName==courseName
            )), Times.Once);
        }
    }
}
