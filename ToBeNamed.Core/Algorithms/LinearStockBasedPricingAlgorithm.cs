using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Core.Algorithms
{
    internal class LinearStockBasedPricingAlgorithm : IPricingAlgorithm
    {
        public double Calculate(IProduct product)
        {
            double availablePerc = (double)product.CurrentStock/product.MaxStock;
            double pricePoint = 100 - availablePerc;

            double stockStep = (product.FloorPrice - product.CeilingPrice)/product.MaxStock;
            double price = stockStep*pricePoint;

            if (price > product.CeilingPrice) price = product.CeilingPrice;
            if (price < product.FloorPrice) price = product.FloorPrice;

            return price;
        }
    }
}
