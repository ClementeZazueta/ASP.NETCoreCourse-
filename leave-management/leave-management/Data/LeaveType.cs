using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<LeaveAllocation> LeaveAllocation { get; set; }
        public virtual ICollection<LeaveHistory> LeaveHistory { get; set; }
    }
}
