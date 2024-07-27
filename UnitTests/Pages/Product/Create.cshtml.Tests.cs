// This file meets the code guidlines. Therefore code standards are acheived for this file

using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// The CreateTests class is used for validation of Onget and Onpost methods to return created products
    /// </summary>

    public class CreateTests
    {
        #region TestSetup

        // Object for CreateModel

        public static CreateModel pageModel;

        [SetUp]

        /// <summary>
        /// Initialize the CreateModel
        /// </summary>
        
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region OnGet
        [Test]

        /// <summary>
        /// Testing a valid results on OnGet method  
        /// </summary>
        
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            // This will actually create a page of dummy data
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount, TestHelper.ProductService.GetAllData().Count());
        }

        #endregion OnGet

        #region OnPostAsync        
        [Test]

        /// <summary>
        /// From onpost method test valid result
        /// </summary>
        
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.OnGet();

            // New Card
            var newData = new ProductModel() {};
            pageModel.Product = newData;
            pageModel.Product.SeriesTitle = "name";

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            //Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        #endregion OnPost
    }
}