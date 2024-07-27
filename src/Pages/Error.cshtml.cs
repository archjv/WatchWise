using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    ///<summary>
    /// To log when an error gets thrown
    /// </summary>
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// The RequestId property contains the requestID specified in the request.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gives boolean result if it's not null or it is empty.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>
        /// ILogger instance is used to log a piece of information
        /// </summary>
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// ErrorModel is a parameter passing the ILogger instance
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// page model’s OnGet() method is invoked when a GET request is sent to the page.
        /// </summary>
        public void OnGet()
        {
            //The Activity.Current Gets or sets the current operation (Activity) for the current thread.
            //The HttpContext.TraceIdentifier Gets or sets a unique identifier to represent this request in trace logs.
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}