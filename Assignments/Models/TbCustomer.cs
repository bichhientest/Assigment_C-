using System;
using System.Collections.Generic;

namespace Assignments.Models
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbCarts = new HashSet<TbCart>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Addresz { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<TbCart> TbCarts { get; set; }
    }
}
