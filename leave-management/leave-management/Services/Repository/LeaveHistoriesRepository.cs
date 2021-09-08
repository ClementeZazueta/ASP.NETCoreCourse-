using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace leave_management.Services.Repository
{
    public class LeaveHistoriesRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveHistoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(LeaveHistory entity)
        {
            _context.LeaveHistories.Add(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveHistory entity)
        {
            _context.LeaveHistories.Remove(entity);
            return await Save();
        }

        public async Task<LeaveHistory> FindById(int id)
        {
            var leaveHistory = await _context.LeaveHistories.FindAsync(id);
            return leaveHistory;
        }

        public async Task<ICollection<LeaveHistory>> GetAll()
        {
            return await _context.LeaveHistories.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(LeaveHistory entity)
        {
            _context.LeaveHistories.Update(entity);
            return await Save();
        }

        public async Task<bool> IsExists(int id)
        {
            var exists = await _context.LeaveHistories.AnyAsync(lh => lh.Id == id);
            return exists;
        }
    }
}
