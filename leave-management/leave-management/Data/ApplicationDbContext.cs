using leave_management.Data.ModelConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using leave_management.Models;

namespace leave_management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new LeaveTypeConfig());
            builder.ApplyConfiguration(new LeaveAllocationConfig());
            builder.ApplyConfiguration(new LeaveHistoryConfig());
        }

        public DbSet<leave_management.Models.LeaveTypeViewModel> LeaveTypeViewModel { get; set; }

        public DbSet<leave_management.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
    }
}
