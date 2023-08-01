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
            // Test ama�l� repository'nin Mock halini olu�tur
            _mockStudentRepository = new Mock<IRepositoryDal<Student>>();
            _studentService = new StudentManager(_mockStudentRepository.Object);
        }

        [Fact]
        public void OgrenciSilmeTesti()
        {
            // Haz�rl�k (Arrange)
            int ogrenciId = 1;

            // Mock repository'den ��renci verisini al�p silme i�lemi yapmak i�in ayarla
            _mockStudentRepository.Setup(repo => repo.GetById(ogrenciId)).Returns(new Student
            {
                StudentId = ogrenciId
            });

            // Act
            var ogrenci = _studentService.TGetById(ogrenciId);
            _studentService.TDelete(ogrenci);

            // Do�rulama (Assert)
            // Repository'nin Delete metodunun beklenen ��renci nesnesiyle �a�r�ld���n� do�rula
            _mockStudentRepository.Verify(repo => repo.Delete(It.Is<Student>(deletedStudent =>
                deletedStudent.StudentId == ogrenciId
            )), Times.Once);
        }
    }
}
