namespace APBD_Cw1_s30115.Models;

public class Student(string firstName, string lastName) : User(firstName, lastName)
{
    public override int GetMaxReservations()
    {
        return 2;
    }
}