using FlatFile.Delimited.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepBinding.Scalability.Model
{
    public sealed class ImportDelimeterLayout : DelimitedLayout<ImportEntity>
    {
        public ImportDelimeterLayout()
        {
            this.WithDelimiter(",")
                .WithHeader()
                .WithMember(x => x.Region)
                .WithMember(x => x.Country)
                .WithMember(x => x.ItemType, c => c.WithName("Item Type"))
                .WithMember(x => x.SalesChannel, c => c.WithName("Sales Channel"))
                .WithMember(x => x.OrderPriority, c => c.WithName("Order Priority"))
                .WithMember(x => x.OrderDate, c => c.WithName("Order Date"))
                .WithMember(x => x.OrderID, c => c.WithName("Order ID"))
                .WithMember(x => x.ShipDate, c => c.WithName("Ship Date"))
                .WithMember(x => x.UnitsSold, c => c.WithName("Units Sold"))
                .WithMember(x => x.UnitPrice, c => c.WithName("Unit Price"))
                .WithMember(x => x.UnitCost, c => c.WithName("Unit Cost"))
                .WithMember(x => x.TotalRevenue, c => c.WithName("Total Revenue"))
                .WithMember(x => x.TotalCost, c => c.WithName("Total Cost"))
                .WithMember(x => x.TotalProfit, c => c.WithName("Total Profit"));
        }
    }
}
