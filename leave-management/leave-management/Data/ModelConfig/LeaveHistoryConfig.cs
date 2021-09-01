using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data.ModelConfig
{
    public class LeaveHistoryConfig : IEntityTypeConfiguration<LeaveHistory>
    {
        public void Configure(EntityTypeBuilder<LeaveHistory> builder)
        {
            builder.HasKey(lh => lh.Id);

            builder.Property(lh => lh.Approved).IsRequired(false);

            builder.HasOne(lh => lh.RequestingEmployee)
                .WithMany(e => e.RequestingEmployee)
                .IsRequired()
                .HasForeignKey(lh => lh.RequestingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(lh => lh.ApprovedBy)
                .WithMany(e => e.ApprovedBy)
                .IsRequired()
                .HasForeignKey(lh => lh.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lh => lh.LeaveType)
                .WithMany(lt => lt.LeaveHistory)
                .HasForeignKey(lh => lh.LeaveTypeId);
        }
    }
}
