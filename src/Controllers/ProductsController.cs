// This file meets the code guidelines, therefore code standards are achieved for this file.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]

    /// <summary>
    /// Derives ProductController sub class from MVC Base class ControllerBase
    /// </summary>
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Getting Products from JsconFileProductServices by adding it to the Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            // ProductService here equals productService from JsonFileProductService
            ProductService = productService;
        }

        // Holding the service and getting it without modifying it
        public JsonFileProductService ProductService { get; }

        [HttpGet]

        /// <summary>
        /// Returns Product Data
        /// </summary>
        public IEnumerable<ProductModel> Get()
        {
            // Returns all data from ProductService
            return ProductService.GetAllData();
        }
    }
}