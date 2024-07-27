// This file meets the code guidelines, therefore code standards are achieved for this file.

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Services;

using ContosoCrafts.WebSite.Models;


namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier

        public JsonFileProductService ProductService { get; set; }

        /// <summary>
        /// constructor for CreateModel
        /// </summary>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        // ProductModel
        [BindProperty]
        public ProductModel Product { get; set; }

        #region OnGet
        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
        }
        #endregion

        #region OnPost
        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            ProductService.CreateData(Product);

            return RedirectToPage("./Index");
        }
        #endregion
    }
}