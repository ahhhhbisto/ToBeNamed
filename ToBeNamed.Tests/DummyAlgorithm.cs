using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Tests
{
    public class DummyAlgorithm : IPricingAlgorithm
    {
        public double Calculate(IProduct product)
        {
            return 1;
        }
    }
}
