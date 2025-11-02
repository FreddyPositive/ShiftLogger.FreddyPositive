using static ShiftLogger.Models.ShiftLoggerEntity.ShifLoggerEntity;
using ShiftLogger.Models;
using ShiftLogger.Models.ShiftLoggerDto;
using Microsoft.EntityFrameworkCore;

namespace ShiftLogger.DataAccess;

public interface IShiftLoggerDataAccess
{
    DateTime GetActiveShiftInTime(int employeeId);
    Task ShiftIn(ShiftDetails shiftDetails);
    Task ShiftOut(ShiftDetails shiftDetails);
}

public class ShiftLoggerDataAcess : IShiftLoggerDataAccess
{
    public readonly ShiftLoggerDbContext _shiftLoggerDbContext;

    public ShiftLoggerDataAcess(ShiftLoggerDbContext shiftLoggerDbContext)
    {
        _shiftLoggerDbContext = shiftLoggerDbContext;
    }

    public async Task ShiftIn(ShiftDetails shiftDetails)
    {
        try
        {
            _shiftLoggerDbContext.Add(shiftDetails);
             await _shiftLoggerDbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Database error: {ex.Message}");
        }
    }

    public async Task ShiftOut(ShiftDetails shiftDetails)
    {

        var shiftOutDetails = await _shiftLoggerDbContext.ShiftDetails.FirstOrDefaultAsync(e => e.EmployeeId == shiftDetails.EmployeeId && e.ShiftStatus ==1);
        
        shiftOutDetails.ShiftEnd = shiftDetails.ShiftEnd;
        shiftOutDetails.TotalWorkingHours = shiftDetails.TotalWorkingHours;
        shiftOutDetails.ShiftStatus = 0;

        await _shiftLoggerDbContext.SaveChangesAsync();
    }
    public DateTime GetActiveShiftInTime(int employeeId)
    {
        var shiftInTime = _shiftLoggerDbContext.ShiftDetails.
                            Where(s => s.EmployeeId == employeeId 
                            && s.ShiftStatus == 1).Select(s => s.ShiftStart)
                            .FirstOrDefault();
        return shiftInTime;
    }

}
