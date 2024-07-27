// This file meets the code guidelines

using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// The class ProductModel, contains information regarding cards like, Id, Maker, Image, Link to Streaming Service, TrailerURL, SeriesTitle, Summary, Rating and Comments.
    /// </summary>
    public class ProductModel
    {
        // Product ID
        public string Id { get; set; }
        
        // Product Maker
        public string Maker { get; set; }

        // Product Image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Product TrailerURL
        public string TrailerURL { get; set; }

        // Link to Streaming service
        public string StreamingServiceURL { get; set; }

        // Product Title
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The SeriesTitle should have a length of more than {2} and less than {1}")]
        public string SeriesTitle { get; set; }

        //Product summary
        public string Summary { get; set; }

        // Number of episodes should be from 1 to 999
        [Range(1, 999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "Number of episodes is required")]

        // Number of Episodes
        public int Episodes { get; set; }

        // Product ratings
        public int[] Ratings { get; set; }

        // Store the Comments entered by the users on this product
        public CommentModel Comment { get; set; } = new CommentModel();

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();
        
        // Converting Jason data to string
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}