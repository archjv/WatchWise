using Bunit;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Test Context used by bUnit
    /// </summary>
    public abstract class BunitTestContext : TestContextWrapper
    {
        [SetUp]

        /// <summary>
        /// The Setup sets the context
        /// </summary>
        
        public void Setup() => TestContext = new Bunit.TestContext();

        [TearDown]

        /// <summary>
        /// When done displose removes it, to free up system resources
        /// </summary>
        
        public void TearDown() => TestContext.Dispose();
    }
}