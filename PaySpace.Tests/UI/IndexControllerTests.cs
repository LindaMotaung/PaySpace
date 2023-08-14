using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using PaySpace.Pages;

namespace PaySpace.Tests.UI
{
    [TestFixture]
    public class IndexControllerTests
    {
        [Test]
        public void MapPostalCodes_ValidCode_ReturnsCorrectId()
        {
            // Arrange
            var model = new IndexModel();

            // Act
            var result = model.MapPostalCodes("7441");

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void MapPostalCodes_InvalidCode_ThrowsException()
        {
            // Arrange
            var model = new IndexModel();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => model.MapPostalCodes(null));
            Assert.Throws<ArgumentNullException>(() => model.MapPostalCodes(""));
            Assert.Throws<ArgumentNullException>(() => model.MapPostalCodes("InvalidCode"));
        }

        [Test]
        public void OnPost_ValidModelState_ReturnsPageResult()
        {
            // Arrange
            var model = new IndexModel();
            model.PostalCode = "7441";
            model.Income = 50000;

            // Act
            var result = model.OnPost();

            // Assert
            Assert.IsInstanceOf<PageResult>(result);
        }

        [Test]
        public void OnPost_InvalidModelState_ReturnsPageResultWithErrors()
        {
            // Arrange
            var model = new IndexModel
            {
                PostalCode = null,
                Income = -5000 // Invalid income
            };

            // Act
            var result = model.OnPost();

            // Assert
            Assert.IsInstanceOf<PageResult>(result);
            Assert.IsFalse(model.ModelState.IsValid);
        }
    }
}
