using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderWares = new HashSet<OrderWare>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; } = null!;

        public virtual UserDetail Customer { get; set; } = null!;
        public virtual ICollection<OrderWare> OrderWares { get; set; }
    }
}
