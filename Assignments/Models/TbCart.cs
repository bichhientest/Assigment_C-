using System;
using System.Collections.Generic;

namespace Assignments.Models
{
    public partial class TbCart
    {
        public TbCart()
        {
            TbCartDetails = new HashSet<TbCartDetail>();
        }

        public int CartId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TbCustomer? Customer { get; set; }
        public virtual ICollection<TbCartDetail> TbCartDetails { get; set; }
    }
}
