using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveHistory
    {
        public int Id { get; set; }
        public string RequestingEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public string ApprovedById { get; set; }

        public virtual Employee RequestingEmployee { get; set; }
        public virtual Employee ApprovedBy { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
