// This file meets the code guidlines. Therefore code standards are acheived for this file
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    ///  The DeleteTests class is used for validation of Onget and Onpost methods to return products and invalid pages
    /// </summary>
    
    public class DeleteTests
    {
        #region TestSetup

        // Object for DeleteModel

        public static DeleteModel pageModel;

        [SetUp]

        /// <summary>
        /// Initialize the DeleteModel
        /// </summary>
        
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]

        /// <summary>
        /// Validation for OnGet method to return all the products
        /// </summary>
        
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("breaking-bad");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Breaking Bad", pageModel.Product.SeriesTitle);
        }
        #endregion OnGet

        #region OnPost
        [Test]

        /// <summary>
        /// Validation for OnPost method to return all the product
        /// </summary>
        
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            ProductModel productModel = new ProductModel();
            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData(productModel);
            pageModel.Product.SeriesTitle = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        [Test]

        /// <summary>
        /// Validation for OnPost invalid method to return invalid page
        /// </summary>
        
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}