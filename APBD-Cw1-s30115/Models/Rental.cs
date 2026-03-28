namespace APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;

public class Rental(User user, Equipment equipment, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    public static int DelayFinePerDayUSD { get; } = 2;
    
    public int Id { get; private set; } = _nextId++;
    public User User { get; set; } = user;
    public Equipment Equipment { get; set; } = equipment;
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;
    
    public RentalStatus Status { get; set; } = RentalStatus.Ongoing;
    public DateTime? ActualReturnDate { get; set; }
    public int FineAmount { get; set; } = 0;
}