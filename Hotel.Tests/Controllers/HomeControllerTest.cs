using System.Web.Mvc;
using FluentAssertions;
using Hotel.Controllers;
using Xunit;

namespace Hotel.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;
            var message = result.ViewBag.Message as string;

            message.Should().Be("Your application description page.");
        }

        [Fact]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }
    }
}