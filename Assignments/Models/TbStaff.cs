using System;
using System.Collections.Generic;

namespace Assignments.Models
{
    public partial class TbStaff
    {
        public string StaffId { get; set; } = null!;
        public string? StaffName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
