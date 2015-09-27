namespace ToBeNamed.Core.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Category { get; set; }
        string Name { get; set; }
        bool Active { get; set; }

        double CurrentPrice { get; set; }
        double FloorPrice { get; set; }
        double CeilingPrice { get; set; }

        long UnitsSoldToday { get; set; }
        long CurrentStock { get; set; }
        long MaxStock { get; set; }
    }
}
