
using APBD_Cw1_s30115.Models;
namespace APBD_Cw1_s30115.Models;

public class Rental(User user, Equipment equipment, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    public int Id { get; set; } = _nextId;

    public User User { get; set; } = user;

    public Equipment Equipment { get; set; } = equipment;

    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;
    
    
}