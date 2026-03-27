namespace APBD_Cw1_s30115.Exceptions;

public class EquipmentNotFoundException (int equipmentId) : Exception ($"ERROR: Equipment with provided ID: {equipmentId} not found!");