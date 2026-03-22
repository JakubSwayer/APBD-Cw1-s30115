namespace APBD_Cw1_s30115.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _nextID = 1;
    public int ID { get; } = _nextID++;

    public string firstName { get; set; } = firstName;
    public string lastName { get; set; } = lastName;

    public abstract int GetMaxReservations();
}