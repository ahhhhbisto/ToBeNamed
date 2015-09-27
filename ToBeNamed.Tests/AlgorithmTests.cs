using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToBeNamed.Core;
using ToBeNamed.Core.Algorithms;
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

        [TestMethod]
        public void TestLinearStockBasedPricingAlgorithm()
        {
            AlgorithmFactory.ActiveAlgorithmType = typeof (LinearStockBasedPricingAlgorithm); // Setting internal type manually.

            var obj = AlgorithmFactory.GetPricingAlgorithm();

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IPricingAlgorithm));
            Assert.IsInstanceOfType(obj, typeof(LinearStockBasedPricingAlgorithm));
        }
    }
}
