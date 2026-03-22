using APBD_Cw1_s30115.Enums;

namespace APBD_Cw1_s30115.Models;

public abstract class Equipment(string name, string model, string manufacturer)
{
    private static int _nextID = 1;
    public int ID { get; } = _nextID++;
    
    public string Name { get; set; } = name;
    public string Model { get; set; } = model;
    public string Manufacturer { get; set; } = manufacturer;

    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;

}