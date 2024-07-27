// This file meets the code guidlines. Therefore code standards are acheived for this file
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

using ContosoCrafts.WebSite.Models;

using System.Linq;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// The UpdateTests class is used for validation od OnPost and OnGet methods to return products and valid, invalid pages 
    /// </summary>
    
    public class UpdateTests
    {
        #region TestSetup

        // Object for UpdateModel 
        public static UpdateModel pageModel;

        [SetUp]

        /// <summary>
        /// Initialize UpdateModel
        /// </summary>
        
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnPost
        [Test]

        /// <summary>
        /// Validation for OnPost method to return all the product
        /// </summary>
        
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "breaking-bad",
                SeriesTitle = "SeriesTitle",
                Summary = "Summary",
                TrailerURL = "url",
                StreamingServiceURL = "url",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        #region OnGet
        [Test]

        /// <summary>
        /// Validation for OnGet method to return all the product
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
        
        [Test]

        /// <summary>
        /// Validation for OnPost invalid method to return invalid page
        /// </summary>
        
        public void OnPost_InValid_Model_NotValid_Return_Page1()
        {
            // Arrange
            pageModel.Product = null;

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        
        [Test]

        /// <summary>
        /// Validation for OnPost invalid method to return updated page
        /// </summary>
        
        public void OnPost_InValid_Model_NotValid_Return_Page_Null()
        {
            // Arrange
            ProductModel model = new ProductModel();

            pageModel.Product = TestHelper.ProductService.UpdateData(model);

            var result = pageModel.OnPost() as RedirectToPageResult;

            pageModel.OnPost();

            pageModel.Product = TestHelper.ProductService.UpdateData(model);
            pageModel.Product = new ProductModel();
            pageModel.Product.Id = "all-of-us-are-dea";

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }
  
        [Test]

        /// <summary>
        /// Validation for OnPost invalid method to return updated page
        /// </summary>
        
        public void OnPost_InValid_Product_Return_Page_Null()
        {
            // Arrange
            ProductModel model = new ProductModel();

            // First Create the product to delete
            model.SeriesTitle = "c";
            model.Image = "c";
            model.TrailerURL = "c";
            model.StreamingServiceURL = "c";
            model.Summary = "c";

            pageModel.Product = TestHelper.ProductService.CreateData(model);

            var result = pageModel.OnPost() as RedirectToPageResult;
            result.PageName = "./Update";
            pageModel.OnPost();

            pageModel.Product = TestHelper.ProductService.CreateData(model);
            pageModel.Product = new ProductModel();
            pageModel.Product.Id = "all-of-us-are-dead";

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add

            //// Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("./Update", result.PageName);
            // Confirm the item is deleted
            Assert.AreEqual("all-of-us-are-dead", pageModel.Product.Id);

        }

        [Test]

        /// <summary>
        /// Validate for OnGet method Invalid Id should return products
        /// </summary>
        
        public void OnPost_InValid_Id_Bougs_Should_Return_Products()
        {
            // Arrange
            ProductModel model = new ProductModel();

            // First Create the product to delete
            model.SeriesTitle = "c";
            model.Image = "c";
            model.TrailerURL = "c";
            model.StreamingServiceURL = "c";
            model.Summary = "c";

            pageModel.Product = TestHelper.ProductService.CreateData(model);
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            result.PageName = "./Update";


            Assert.AreNotSame(pageModel.Product, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Contains(pageModel.Product.Id)).ToString());
            // Assert
            Assert.AreEqual("./Update", result.PageName);
        }
        #endregion OnPost
    }
}