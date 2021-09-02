using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Create(LeaveType entity)
        {
            _context.LeaveTypes.Add(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveType entity)
        {
            _context.LeaveTypes.Remove(entity);
            return await Save();
        }

        public async Task<LeaveType> FindById(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            return leaveType;
        }

        public async Task<IEnumerable<LeaveType>> GetAll()
        {
            return await _context.LeaveTypes.ToListAsync();                                                                             
        }

        public Task<IEnumerable<LeaveType>> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveType entity)
        {
            _context.LeaveTypes.Update(entity);
            return await Save();
        }
    }
}
