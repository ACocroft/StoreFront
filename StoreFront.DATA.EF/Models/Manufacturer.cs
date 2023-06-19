using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Wares = new HashSet<Ware>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string? ManufacturerCity { get; set; }
        public string MaufacturerCountry { get; set; } = null!;

        public virtual ICollection<Ware> Wares { get; set; }
    }
}
