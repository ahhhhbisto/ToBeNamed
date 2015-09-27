using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Tests
{
    public static class TestObjects
    {
        private static readonly TestProduct _testProduct = new TestProduct
        {
            Active = true,
            Category = "Tests",
            CeilingPrice = 3.0,
            CurrentPrice = 1.0,
            FloorPrice = 1.0,
            CurrentStock = 5,
            Id = 1,
            MaxStock = 10,
            Name = "TestProduct",
            UnitsSoldToday = 5
        };

        public static IProduct TestProduct{get { return _testProduct; }}
    }

    
    class TestProduct : IProduct
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public double CurrentPrice { get; set; }
        public double FloorPrice { get; set; }
        public double CeilingPrice { get; set; }
        public long UnitsSoldToday { get; set; }
        public long CurrentStock { get; set; }
        public long MaxStock { get; set; }
    }
}
