using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Create(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Add(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveAllocation entity)
        {
           _context.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations.FindAsync(id);
            return leaveAllocation;
        }

        public async Task<IEnumerable<LeaveAllocation>> GetAll()
        {
            return await _context.LeaveAllocations.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
           _context.LeaveAllocations.Update(entity);
            return await Save();
        }
    }
}
