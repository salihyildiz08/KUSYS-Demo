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
            // Test amaçlý repository'nin Mock halini oluþtur
            _mockStudentRepository = new Mock<IRepositoryDal<Student>>();
            _studentService = new StudentManager(_mockStudentRepository.Object);
        }

        [Fact]
        public void OgrenciDuzenlemeTesti()
        {
            // Hazýrlýk (Arrange)
            int ogrenciId = 1;
            string ad = "Muzaffer";
            string soyad = "Yýldýz";
            DateTime dogumTarihi = new DateTime(2000, 9, 8);

            // Mock repository'den öðrenci verisini alýp düzenleme yapmak için ayarla
            _mockStudentRepository.Setup(repo => repo.GetById(ogrenciId)).Returns(new Student
            {
                StudentId = ogrenciId,
                FirstName = "Eski Ad", // Mevcut adý
                LastName = "Eski Soyad", // Mevcut soyadý
                BirthDate = new DateTime(1999, 1, 1) // Mevcut doðum tarihi
            });

            // Act
            var ogrenci = _studentService.TGetById(ogrenciId);
            ogrenci.FirstName = ad;
            ogrenci.LastName = soyad;
            ogrenci.BirthDate = dogumTarihi;
            _studentService.TUpdate(ogrenci);

            // Doðrulama (Assert)
            // Repository'nin Update metodunun beklenen öðrenci nesnesiyle çaðrýldýðýný doðrula
            _mockStudentRepository.Verify(repo => repo.Update(It.Is<Student>(updatedStudent =>
                updatedStudent.StudentId == ogrenciId &&
                updatedStudent.FirstName == ad &&
                updatedStudent.LastName == soyad &&
                updatedStudent.BirthDate == dogumTarihi
            )), Times.Once);
        }
    }
}
