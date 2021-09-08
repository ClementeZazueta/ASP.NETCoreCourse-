using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class CreateLeaveAllocationViewModel
    {
        public int NumberUpdated { get; set; }
        public IEnumerable<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
