using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveType>> GetLeaveTypesWithDetails()
        {
            var leaveTypes = await _dbContext.LeaveTypes.ToListAsync();
            return leaveTypes;
        }

        public async Task<LeaveType> GetLeaveTypeWithDetails(int id)
        {
            var leaveType = await _dbContext.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            return leaveType;
        }

        public async Task<LeaveType> UpdateLeaveTypeWithDetails(LeaveType leaveType)
        {
            _dbContext.LeaveTypes.Update(leaveType);
            _dbContext.Entry(leaveType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return leaveType;
        }
    }
}
