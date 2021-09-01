using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Services.Repository
{
    public class LeaveTypesRepository : ILeaveTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<LeaveType>> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveType>> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LeaveType entity)
        {
            throw new NotImplementedException();
        }
    }
}
