using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveAllocation
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
