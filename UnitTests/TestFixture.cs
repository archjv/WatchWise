using System.IO;

using NUnit.Framework;

namespace UnitTests
{
    [SetUpFixture]

    /// <summary>
    /// Marks a class that contains tests and, optionally, setup or teardown methods.
    /// </summary>
    public class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        [OneTimeSetUp]

        /// <summary>
        /// Runs the code once when the test harness starts up.
        /// 
        /// This will copy over the latest version of the database files.
        /// </summary>
        public void RunBeforeAnyTests()
        {

            // C:\repos\5110\ClassBaseline\UnitTests\bin\Debug\net5.0\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\bin\Debug\net5.0\wwwroot\data

            // var DataWebPath = "../../../../src/bin/Debug/net5.0/wwwroot/data";
            var DataWebPath = "../../../../src/wwwroot/data";
            var DataUTDirectory = "wwwroot";
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }
            
            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(DataWebPath);
            foreach (var filename in filePaths)
            {
                string OriginalFilePathName = filename.ToString();
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }
        }

        [OneTimeTearDown]

        /// <summary>
        /// This method is called after all the tests in the namespace as well as their individual or fixture teardowns have completed exection.
        /// </summary>
        public void RunAfterAnyTests()
        {
        }
    }
}