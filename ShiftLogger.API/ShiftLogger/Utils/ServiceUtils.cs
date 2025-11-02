using ShiftLogger.DataAccess;

namespace ShiftLogger.Utils;

public class ServiceUtils
{
    public readonly IShiftLoggerDataAccess _shiftLoggerDataAccess;

    public ServiceUtils(IShiftLoggerDataAccess shiftLoggerDataAccess)
    {
        _shiftLoggerDataAccess = shiftLoggerDataAccess;
    }
    public decimal GetTotalWorkingHours(int employeeId, DateTime shiftEnd)
    {
        DateTime shiftInTime = _shiftLoggerDataAccess.GetActiveShiftInTime(employeeId);

        TimeSpan timeDifference = shiftEnd - shiftInTime;

        Decimal totalWorkingHours = (decimal)timeDifference.TotalHours;

        return totalWorkingHours;
    }
}
