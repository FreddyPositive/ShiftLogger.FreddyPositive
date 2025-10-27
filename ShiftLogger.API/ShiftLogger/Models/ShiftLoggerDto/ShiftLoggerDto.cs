namespace ShiftLogger.Models.ShiftLoggerDto;

public class ShiftLoggerDto
{
    public class EmployeeListDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ShiftDetailsDto
    {
        public int EmployeeId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
