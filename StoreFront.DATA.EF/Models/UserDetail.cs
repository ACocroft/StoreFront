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

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
