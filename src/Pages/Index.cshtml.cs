// This file meets the code guidelines, therefore code standards are achieved for this file.

using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;

using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Returns the Product list
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// ILogger instance is used to log a piece of information
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// IndexModel is a parameter passing the ILogger instance
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Gets the Product List
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Retrieve those products in that service.
        /// 
        /// it's a private set.Only this class can set them.
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        //To store the search string from the search bar
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        /// <summary>
        /// This is used to get all of the data
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public IActionResult OnGet(string SearchString)
        {
            // Search string is not null or empty then find the products in product list
            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.GetAllData().Where(m => m.SeriesTitle.ToLower().StartsWith(SearchString.ToLower()));
            }

            // Search string is null or empty then return all products
            if (string.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.GetAllData();
            }

            // Search string is not found in product list then return all products
            if (Products.Count() == 0)
            {
                Products = ProductService.GetAllData();
            }

            return Page();
        }
    }
}