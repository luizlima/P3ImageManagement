using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using P3ImageManagement.Application.Interfaces;
using P3ImageManagement.Application.Services;
using P3ImageManagement.Domain.Models;
using P3ImageManagement.Domain.Interfaces;
using System.Collections.Generic;

namespace P3ImageManagement.Application.Tests
{
    [TestClass]
    public class CategoryAppServiceTest
    {
        private Mock<ICategoryAppService> mockCategoryAppService;
        private Mock<IRepository<Category>> mockCategoryRepository;
        private CategoryAppService categoryAppService;

        [TestInitialize]
        public void InitializeTests()
        {
            mockCategoryAppService = new Mock<ICategoryAppService>();
            mockCategoryRepository = new Mock<IRepository<Category>>();
            categoryAppService = new CategoryAppService(mockCategoryRepository.Object);
            
        }

        [TestMethod]
        public void Quando_RecuperarPorId_RecuperarPorId_No_Repositorio()
        {
            var categoryExpected = new Category();
            mockCategoryRepository.Setup(_ => _.GetById(1)).Returns(categoryExpected);

            var categoryViewModel = categoryAppService.GetById(1);
            var categoryActual = new Category(categoryViewModel.Description, categoryViewModel.Slug);

            mockCategoryRepository.VerifyAll();
            Assert.AreEqual(categoryExpected, categoryActual);
        }

        [TestMethod]
        public void Quando_RecuperarTodasAsCategorias_Recuperar_todos_do_Repositorio()
        {
            var expected = new List<Category>();
            mockCategoryRepository.Setup(_ => _.GetAll()).Callback((Category c) => expected.Add(c));

            var actual = categoryAppService.GetAll();

            mockCategoryRepository.VerifyAll();
            Assert.AreSame(expected, actual);
        }



        
    }
}
