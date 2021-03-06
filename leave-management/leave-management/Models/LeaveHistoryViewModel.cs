using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveHistoryViewModel
    {
        public int Id { get; set; }
        public string RequestingEmployeeId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public string ApprovedById { get; set; }

        public virtual EmployeeViewModel RequestingEmployee { get; set; }
        public virtual EmployeeViewModel ApprovedBy { get; set; }
        public virtual LeaveTypeViewModel LeaveType { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}
