using System.ComponentModel.DataAnnotations;

namespace ShiftLogger.Models.ShiftLoggerEntity;

public class ShifLoggerEntity
{
    public class EmployeeList
    {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public DateTime CreatedDate { get; set; }
      public ICollection<ShiftDetails> Shifts { get; set; }
    }
    public class ShiftDetails
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public int ShiftStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public EmployeeList Employee { get; set; }
    }
}
