using System;
using System.Collections.Generic;

namespace Assignments.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Pictrue { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
