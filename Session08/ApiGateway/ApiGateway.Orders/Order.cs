using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public long PersonId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public long TotalPrice { get; set; }


    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
    }
}
