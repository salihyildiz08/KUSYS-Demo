using Xunit;
using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Moq;
using System;

namespace KusysUnitTest
{
    public class EditStudentTest
    {
        private readonly IStudentService _studentService;
        private readonly Mock<IRepositoryDal<Student>> _mockStudentRepository;

        public EditStudentTest()
        {
            // Test ama�l� repository'nin Mock halini olu�tur
            _mockStudentRepository = new Mock<IRepositoryDal<Student>>();
            _studentService = new StudentManager(_mockStudentRepository.Object);
        }

        [Fact]
        public void OgrenciDuzenlemeTesti()
        {
            // Haz�rl�k (Arrange)
            int ogrenciId = 1;
            string ad = "Muzaffer";
            string soyad = "Y�ld�z";
            DateTime dogumTarihi = new DateTime(2000, 9, 8);

            // Mock repository'den ��renci verisini al�p d�zenleme yapmak i�in ayarla
            _mockStudentRepository.Setup(repo => repo.GetById(ogrenciId)).Returns(new Student
            {
                StudentId = ogrenciId,
                FirstName = "Eski Ad", // Mevcut ad�
                LastName = "Eski Soyad", // Mevcut soyad�
                BirthDate = new DateTime(1999, 1, 1) // Mevcut do�um tarihi
            });

            // Act
            var ogrenci = _studentService.TGetById(ogrenciId);
            ogrenci.FirstName = ad;
            ogrenci.LastName = soyad;
            ogrenci.BirthDate = dogumTarihi;
            _studentService.TUpdate(ogrenci);

            // Do�rulama (Assert)
            // Repository'nin Update metodunun beklenen ��renci nesnesiyle �a�r�ld���n� do�rula
            _mockStudentRepository.Verify(repo => repo.Update(It.Is<Student>(updatedStudent =>
                updatedStudent.StudentId == ogrenciId &&
                updatedStudent.FirstName == ad &&
                updatedStudent.LastName == soyad &&
                updatedStudent.BirthDate == dogumTarihi
            )), Times.Once);
        }
    }
}
