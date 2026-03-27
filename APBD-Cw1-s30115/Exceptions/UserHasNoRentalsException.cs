namespace APBD_Cw1_s30115.Exceptions;

public class UserHasNoRentalsException : Exception
{
    public UserHasNoRentalsException(int userId)
    {
        Console.Write($"ERROR: User with provided ID: {userId} has no rentals!");
    }
}