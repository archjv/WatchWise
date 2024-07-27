using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Manages the Privacy of the website.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// ILogger instance is used to log a piece of information
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// ErrorModel is a parameter passing the ILogger instance
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// page model’s OnGet() method is invoked when a GET request is sent to the page.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
