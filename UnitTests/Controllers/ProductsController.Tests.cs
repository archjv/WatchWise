using ContosoCrafts.WebSite.Controllers;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using static ContosoCrafts.WebSite.Controllers.ProductsController;


namespace UnitTests.Controllers
{

    /// <summary>
    /// Class containing unit test cases to ProductController
    /// </summary>
    
    public class ProductsControllerTests
    {

        //Creating and instance of ProductsController

        public static ProductsController testProductController;


        #region TestSetup
        [SetUp]

        /// <summary>
        /// Test initialize
        /// </summary>
        
        public void Testinitialize()
        {
            testProductController = new ProductsController(TestHelper.ProductService);
        }

        #endregion
        
        [Test]

        /// <summary>
        /// Testing if get is valid should return products
        /// </summary>
        
        public void Get_Valid_Should_Return_List_Of_Products()
        {

            //Arrange
            var data = testProductController.Get().ToList();


            //Act


            //Assert
            Assert.AreEqual(typeof(List<ProductModel>), data.GetType());
        }
        
        [Test]

        /// <summary>
        /// Testing get valid tostring should return string
        /// </summary>
        
        public void Get_Valid_ToString_Should_Return_String()
        {
            //Arrange
            var data = testProductController.Get().FirstOrDefault().ToString();

            //Act


            //Assert
            Assert.AreEqual(typeof(string), data.GetType());
        }
    }
}