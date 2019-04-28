using Dapper.Contrib.Extensions;
using DeepDive.Extension.SQLBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepBinding.Scalability
{
    [Dapper.Contrib.Extensions.Table("Sales")]
    public class ImportEntity : IWriterEntity
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime OrderDate { get; set; }
        public long OrderID { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit {get; set;}
    }
}
