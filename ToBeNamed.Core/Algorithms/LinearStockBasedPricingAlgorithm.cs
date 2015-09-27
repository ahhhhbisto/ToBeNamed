using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Core.Algorithms
{
    internal class LinearStockBasedPricingAlgorithm : IPricingAlgorithm
    {
        public double Calculate(IProduct product)
        {
            long soldStock = product.MaxStock - product.CurrentStock;

            double stockStep = (product.CeilingPrice - product.FloorPrice)/product.MaxStock;
            double price = product.FloorPrice + (stockStep*soldStock);

            if (price > product.CeilingPrice) price = product.CeilingPrice;
            if (price < product.FloorPrice) price = product.FloorPrice;

            return price;
        }
    }
}
