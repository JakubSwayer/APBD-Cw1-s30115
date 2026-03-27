namespace APBD_Cw1_s30115.Exceptions;

public class IdNotFoundException : Exception
{
    public IdNotFoundException(int equipmentId)
    {
        Console.Write($"ERROR: Equipment with provided ID: {equipmentId} not found!");
    }
    
}