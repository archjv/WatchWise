using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Gets the path to products.json file
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// Gets the absolute path to the directory that contains the web-servable application content files.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        ///  To provide information about hosting & can get data about path from it
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Gets the file path and name to load
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Gets the json text and convert to a list
        /// </summary>
        public IEnumerable<ProductModel> GetAllData()
        {
            // C#8 using declaration
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            if (data.Id == null)
            {
                CreateData(data);
                return data;
            }
            else
            {
                var products = GetAllData();
                var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
                if (productData != null)
                {
                    // Update the data to the new passed in values
                    productData.SeriesTitle = data.SeriesTitle;
                    if (data.Summary != null)
                        productData.Summary = data.Summary.Trim();
                    productData.Episodes = data.Episodes;
                    productData.TrailerURL = data.TrailerURL;
                    productData.StreamingServiceURL = data.StreamingServiceURL;
                    productData.Image = data.Image;

                    productData.CommentList = data.CommentList;

                    SaveData(products);
                }
                return productData;
            }

        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            //Used to create a file and stores the data in the form of individual bytes.
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData(ProductModel productModel)
        {
            productModel.Id = System.Guid.NewGuid().ToString();

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(productModel);

            SaveData(dataSet);

            return productModel;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

    }
}