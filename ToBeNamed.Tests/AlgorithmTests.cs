using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void TestAlgorithmRetrieval()
        {
            var obj = AlgorithmFactory.GetPricingAlgorithm();

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IPricingAlgorithm));
        }
    }
}
