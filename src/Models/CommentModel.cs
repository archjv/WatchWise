// This file meets the code guidelines. Therefore code standards are achieved for this file.

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class CommentModel contains information about, Reviews given by the viewers about the TV Shows.
    /// </summary>
    public class CommentModel
    {
        // The ID for this comment, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // The Comment
        public string Comment { get; set; }
    }
}