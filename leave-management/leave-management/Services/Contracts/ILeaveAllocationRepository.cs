using leave_management.Data;
using System.Threading.Tasks;

namespace leave_management.Services.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        public bool CheckAllocation(int leaveTypeId, string employeeId);
    }
}
