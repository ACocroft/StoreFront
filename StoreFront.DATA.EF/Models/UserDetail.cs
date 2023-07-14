using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
