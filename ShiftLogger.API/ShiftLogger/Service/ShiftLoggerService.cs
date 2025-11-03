using ShiftLogger.DataAccess;
using ShiftLogger.Utils;
using static ShiftLogger.Models.ShiftLoggerDto.ShiftLoggerDto;
using static ShiftLogger.Models.ShiftLoggerEntity.ShifLoggerEntity;

namespace ShiftLogger.Service;

public interface IShiftLoggerService
{
    Task ShiftIn(ShiftInDto shiftInDto);
    Task ShiftOut(ShiftOutDto shiftOutDto);
}

public class ShiftLoggerService : IShiftLoggerService
{
    public readonly IShiftLoggerDataAccess _shiftLoggerDataAccess;
    private readonly ServiceUtils _serviceUtils;

    public ShiftLoggerService(IShiftLoggerDataAccess shiftLoggerDataAccess, ServiceUtils serviceUtils)
    {
        _shiftLoggerDataAccess = shiftLoggerDataAccess;
        _serviceUtils = serviceUtils;
    }

    public async Task ShiftIn(ShiftInDto shiftInDto)
    {
        try
        {
            var shiftIn = new ShiftDetails { EmployeeId = shiftInDto.EmployeeId, ShiftStart = DateTime.Now, ShiftStatus = 1 };
           
            await _shiftLoggerDataAccess.ShiftIn(shiftIn);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error during shift in operation.", ex);
        }
    }

    public async Task ShiftOut(ShiftOutDto shiftOutDto)
    {
        try
        {
            var shiftOut = new ShiftDetails { EmployeeId = shiftOutDto.EmployeeId, ShiftEnd = DateTime.Now, TotalWorkingHours = _serviceUtils.GetTotalWorkingHours(shiftOutDto.EmployeeId, DateTime.Now), ShiftStatus = 0 };
          
            await _shiftLoggerDataAccess.ShiftOut(shiftOut);
        }
        catch(Exception ex)
        {
            throw new ApplicationException("Error during shift out operation.", ex);
        }
    }
}
