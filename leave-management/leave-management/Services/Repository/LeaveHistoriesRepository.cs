using leave_management.Data;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<bool> Create(LeaveHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<LeaveHistory>> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveHistory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LeaveHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
