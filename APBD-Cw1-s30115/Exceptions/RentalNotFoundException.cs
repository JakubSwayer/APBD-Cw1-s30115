namespace APBD_Cw1_s30115.Exceptions;

public class RentalNotFoundException : Exception
{
    public RentalNotFoundException(int rentalId)
    {
        Console.Write($"ERROR: Rental with provided ID: {rentalId} not found!");
    }
}