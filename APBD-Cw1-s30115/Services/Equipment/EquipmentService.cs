using APBD_Cw1_s30115.Services.Equipment;

namespace APBD_Cw1_s30115.Services;

public class EquipmentService : IEquipmentService
{
    private List<Models.Equipment> _equipments = []
    
    public void AddEquipment(Models.Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public List<Models.Equipment> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Models.Equipment> GetAvailable()
    {
        throw new NotImplementedException();
    }

    public Models.Equipment DeleteEquipment(int equipmentId)
    {
        if 
    }

    public void SetStatusRented(int equipmentId)
    {
        throw new NotImplementedException();
    }

    public void SetStatusAvailable(int equipmentId)
    {
        throw new NotImplementedException();
    }
}