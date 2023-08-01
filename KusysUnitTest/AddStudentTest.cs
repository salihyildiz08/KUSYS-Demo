using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class AddStudentTest
    {
        private readonly IStudentService _studentService;
        private readonly Mock<IRepositoryDal<Student>> _mockStudentRepository;

        public AddStudentTest()
        {
            // Mock the repository for testing purposes
            _mockStudentRepository = new Mock<IRepositoryDal<Student>>();
            _studentService = new StudentManager(_mockStudentRepository.Object);
        }

        [Fact]
        public void AddStudent()
        {
            // Arrange
            string firstName = "Salih";
            string lastName = "Yýldýz";
            DateTime birthDate = new DateTime(1996, 9, 8);

            Student s = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            // Setup the mock repository to expect Add method call
            _mockStudentRepository.Setup(repo => repo.Add(It.IsAny<Student>()));

            // Act
            _studentService.TAdd(s);

            // Assert
            // Verify that the Add method of the repository was called with the expected student object
            _mockStudentRepository.Verify(repo => repo.Add(It.Is<Student>(student =>
                student.FirstName == firstName &&
                student.LastName == lastName &&
                student.BirthDate == birthDate
            )), Times.Once);
        }
    }
}
