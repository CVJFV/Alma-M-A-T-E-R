using System.ComponentModel.DataAnnotations;

namespace API
{
    public class EmployeeToTrip
    {
        public int EmployeeToTripID { get; set; }
        public string Status { get; set; } //PENDING, APPROVED
        public bool WasRead { get; set; } //Notification to user
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
        
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}