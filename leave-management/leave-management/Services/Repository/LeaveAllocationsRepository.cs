using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Services.Repository
{
    public class LeaveAllocationsRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<LeaveAllocation>> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveAllocation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
