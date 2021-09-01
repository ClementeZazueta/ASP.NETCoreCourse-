using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data.ModelConfig
{
    public class LeaveAllocationConfig : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.HasKey(la => la.Id);

            builder.Property(la => la.NumberOfDays).IsRequired();

            builder.HasOne(la => la.LeaveType)
                .WithMany(lt => lt.LeaveAllocation)
                .HasForeignKey(la => la.LeaveTypeId);

            builder.HasOne(la => la.Employee)
                .WithMany(lt => lt.LeaveAllocation)
                .HasForeignKey(la => la.EmployeeId);
        }
    }
}
