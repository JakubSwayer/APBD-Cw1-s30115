namespace APBD_Cw1_s30115.Exceptions;

public class RentalNotFoundException (int rentalId) : Exception ($"ERROR: Rental with provided ID: {rentalId} not found!");
