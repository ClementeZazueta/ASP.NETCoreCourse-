using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Services.Contracts
{
    public interface ILeaveTypesRepository : IRepositoryBase<LeaveType>
    {
        Task<IEnumerable<LeaveType>> GetEmployeesByLeaveType(int id);
    }
}
