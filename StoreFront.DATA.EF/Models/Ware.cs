using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Ware
    {
        public Ware()
        {
            OrderWares = new HashSet<OrderWare>();
        }

        public string WaresName { get; set; } = null!;
        public int WaresId { get; set; }
        public string Description { get; set; } = null!;
        public int TypeId { get; set; }
        public decimal? Price { get; set; }
        public int ManufacturerId { get; set; }
        public int StockStatusId { get; set; }
        public int? Quantity { get; set; }

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual StockStatus StockStatus { get; set; } = null!;
        public virtual Type Type { get; set; } = null!;
        public virtual ICollection<OrderWare> OrderWares { get; set; }
    }
}
