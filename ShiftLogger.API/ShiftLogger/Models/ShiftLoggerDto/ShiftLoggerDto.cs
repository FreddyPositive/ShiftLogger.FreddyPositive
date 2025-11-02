namespace ShiftLogger.Models.ShiftLoggerDto;

public class ShiftLoggerDto
{
    public class EmployeeListDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ShiftInDto
    {
        public int EmployeeId { get; set; }
    }
    public class ShiftOutDto
    {
        public int EmployeeId { get; set; }
    }
}
