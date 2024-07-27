namespace UnitTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using NUnit.Framework;


    /// <summary>
    /// Set of initial tests.
    /// </summary>
    public class StartupTests
    {
        #region TestSetup
        [SetUp]

        /// <summary>
        /// Test initializing
        /// </summary>
        
        public void TestInitialize()
        {
        }

        /// <summary>
        /// startup class
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        
        #region ConfigureServices
        [Test]

        /// <summary>
        /// Testing for startup configureServices valid should pass
        /// </summary>
        
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        
        #region Configure
        [Test]

        /// <summary>
        /// Testing for startup configure valid default should pass
        /// </summary>
        
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion Configure
    }
}