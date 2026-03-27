namespace APBD_Cw1_s30115.Exceptions;

public class EquipmentNotAvailableException : Exception
{
    public EquipmentNotAvailableException(int equipmentId)
    {
        Console.Write($"ERROR: Equipment with provided ID: {equipmentId} is not available!");
    }
}