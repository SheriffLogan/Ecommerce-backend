using System;
using System.Collections.Generic;

namespace Ecommerce1.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string OrderNo { get; set; }
        public decimal? OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    }
}
