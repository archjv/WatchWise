// This file meets the code guidlines. Therefore code standards are acheived for this file
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]

        /// <summary>
        /// Initialize ReadModel
        /// </summary>
        
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup
        
        #region OnGet
        [Test]

        /// <summary>
        /// Validate for OnGet method Invalid Id should return products
        /// </summary>
        
        public void OnGet_InValid_Id_Bougs_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }

        [Test]

        /// <summary>
        /// Validation for OnGet method to return all the products
        /// </summary>
        
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("squid-game");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Squid Game", pageModel.Product.SeriesTitle);
        }
        #endregion OnGet
    }
}