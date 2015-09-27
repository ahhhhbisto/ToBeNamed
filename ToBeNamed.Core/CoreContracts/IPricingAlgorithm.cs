namespace ToBeNamed.Core.Interfaces
{
    public interface IPricingAlgorithm
    {
        double Calculate(IProduct product);
    }
}
