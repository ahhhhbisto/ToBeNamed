using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            var product = TestObjects.TestProduct;
            var price = obj.Calculate(product);
            var expectedPrice = product.FloorPrice + ((product.CeilingPrice - product.FloorPrice)/2);
            Assert.AreEqual(price, expectedPrice);
            Assert.IsTrue(price > product.FloorPrice);
            Assert.IsTrue(price < product.CeilingPrice);
        }

        [TestMethod]
        public void TestAlgorithmDiscovery()
        {
            AlgorithmFactory.SetupAvailableAgorithmTypes();

            Assert.IsTrue(AlgorithmFactory.AvailableAlgorithmTypes.Any(t => t == typeof(DummyAlgorithm))); // Check that available types contains our test type DummyAlgorithm

            AlgorithmFactory.ActiveAlgorithmType = typeof (DummyAlgorithm);
            var obj = AlgorithmFactory.GetPricingAlgorithm();

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(DummyAlgorithm));
            var price = obj.Calculate(TestObjects.TestProduct);
            Assert.AreEqual(price, 1);
        }
    }
}
