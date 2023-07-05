using System;
using System.Collections.Generic;

namespace Ecommerce1.Models
{
    public partial class OrderItems
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Unitprice { get; set; }
        public decimal? Discount { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
