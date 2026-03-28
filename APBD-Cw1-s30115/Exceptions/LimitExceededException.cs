namespace APBD_Cw1_s30115.Exceptions;

public class LimitExceededException(int userId, int limit) 
    : Exception($"ERROR: User with ID {userId} has reached the maximum limit of {limit} active rentals.");