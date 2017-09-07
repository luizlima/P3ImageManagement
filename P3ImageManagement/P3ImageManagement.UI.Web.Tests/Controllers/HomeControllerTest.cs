using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3ImageManagement.UI.Web;
using P3ImageManagement.UI.Web.Controllers;

namespace P3ImageManagement.UI.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
