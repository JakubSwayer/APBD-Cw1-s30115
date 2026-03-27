namespace APBD_Cw1_s30115.Exceptions;

public class EquipmentNotAvailableException(int equipmentId)
    : Exception($"ERROR: Equipment with provided ID: {equipmentId} is not available!");
