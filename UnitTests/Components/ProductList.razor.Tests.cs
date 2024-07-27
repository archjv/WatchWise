// This file meets the code guidelines. Therefore code standards are achieved for this file.

using Bunit;

using NUnit.Framework;

using ContosoCrafts.WebSite.Components;

using Microsoft.Extensions.DependencyInjection;

using ContosoCrafts.WebSite.Services;

using System.Linq;
using ContosoCrafts.WebSite.Models;
using AngleSharp.Common;

namespace UnitTests.Components
{

    /// <summary>
    /// Test cases for Product List for returning content
    /// </summary>
    
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// Initializes a test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

       

        /// <summary>
        /// Test for returning list of Products. 
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            _ = Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            // Act
            var page = RenderComponent<ProductList>(parameters => parameters
                    .Add(p => p.Products, TestHelper.ProductService.GetAllData()));

            // Get the Cards returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("All of Us Are Dead"));
        }

    }
}