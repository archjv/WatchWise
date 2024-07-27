// This file meets the code guidelines, therefore code standards are achieved for this file.

using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// The IndexTests class is used for validation of Onget methods to obtain the product lists and initialize new instances of the class
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        public static IndexModel pageModel;
        
        [SetUp]

        /// <summary>
        /// Initialize the IndexModel
        /// </summary>
        
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();
            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        [Test]

        /// <summary>
        /// Validate the OnGet Methon to retrieve the product list
        /// </summary>
        
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Act
            pageModel.OnGet("13");
            // Assert
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            
        }
        #endregion OnGet

        #region OnGet
        /// <summary>
        /// Unit test for checking valid empty search string returns all of the products
        /// </summary>
        [Test]
        public void OnGet_Valid_Empty_Search_String_Should_Return_All_Products()
        {
            // Arrange

            // Act
            pageModel.SearchString = "";
            var result = pageModel.OnGet(pageModel.SearchString);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreNotEqual(null, pageModel.Products);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.RazorPages.PageResult", result.ToString());
        }
        #endregion OnGet

        #region OnGet
        /// <summary>
        /// Unit test for checking null search string returns all of the products
        /// </summary>
        [Test]
        public void OnGet_Valid_Null_Search_String_Should_Return_All_Products()
        {
            // Arrange

            // Act
            pageModel.SearchString = null;
            var result = pageModel.OnGet(pageModel.SearchString);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreNotEqual(null, pageModel.Products);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.RazorPages.PageResult", result.ToString());
        }
        #endregion OnGet

        #region OnGet
        /// <summary>
        /// Unit test for checking invalid search string returns all of the products
        /// </summary>
        [Test]
        public void OnGet_Invalid_Search_String_Should_Return_All_Products()
        {
            // Arrange

            // Act
            pageModel.SearchString = "asdfgqwer";
            var result = pageModel.OnGet(pageModel.SearchString);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.RazorPages.PageResult", result.ToString());
        }
        #endregion OnGet

        #region OnGet
        /// <summary>
        /// Unit test for checking valid search string returns corresponding product
        /// </summary>
        [Test]
        public void OnGet_Valid_Search_String_Should_Return_Correct_Product()
        {
            // Arrange

            // Act
            pageModel.SearchString = "13";
            var result = pageModel.OnGet(pageModel.SearchString);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(1, pageModel.Products.Count());
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.RazorPages.PageResult", result.ToString());
        }
        #endregion OnGet
    }
}