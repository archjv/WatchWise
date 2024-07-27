// This file meets the code guidelines. Therefore code standards are achieved for this file.

using ContosoCrafts.WebSite.Models;

using ContosoCrafts.WebSite.Pages.Product;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace UnitTests.Models
{
    public class ProductModelTest
    {
        [Test]

        /// <summary>
        /// Validate ToString menthod for ProductMOdel
        /// </summary>
        
        public void Valid_ToString_Return_True()
        {
            // Arrange

            // Act
            ProductModel productModel = new ProductModel();
            productModel.SeriesTitle = "All of Us Are Dead";
            string result = productModel.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("All of Us Are Dead"));
        }
    }
}