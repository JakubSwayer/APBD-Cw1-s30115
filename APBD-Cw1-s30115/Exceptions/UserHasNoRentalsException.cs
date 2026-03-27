namespace APBD_Cw1_s30115.Exceptions;

public class UserHasNoRentalsException (int userId) : Exception ($"ERROR: User with provided ID: {userId} has no rentals!");
