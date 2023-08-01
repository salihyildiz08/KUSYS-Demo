using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class DeleteStudentTest
    {
        private readonly IStudentService _studentService;
        private readonly Mock<IRepositoryDal<Student>> _mockStudentRepository;

        public DeleteStudentTest()
        {
            // Test amaçlý repository'nin Mock halini oluþtur
            _mockStudentRepository = new Mock<IRepositoryDal<Student>>();
            _studentService = new StudentManager(_mockStudentRepository.Object);
        }

        [Fact]
        public void OgrenciSilmeTesti()
        {
            // Hazýrlýk (Arrange)
            int ogrenciId = 1;

            // Mock repository'den öðrenci verisini alýp silme iþlemi yapmak için ayarla
            _mockStudentRepository.Setup(repo => repo.GetById(ogrenciId)).Returns(new Student
            {
                StudentId = ogrenciId
            });

            // Act
            var ogrenci = _studentService.TGetById(ogrenciId);
            _studentService.TDelete(ogrenci);

            // Doðrulama (Assert)
            // Repository'nin Delete metodunun beklenen öðrenci nesnesiyle çaðrýldýðýný doðrula
            _mockStudentRepository.Verify(repo => repo.Delete(It.Is<Student>(deletedStudent =>
                deletedStudent.StudentId == ogrenciId
            )), Times.Once);
        }
    }
}
