using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;
using APBD_Cw1_s30115.Services.Equipment;

namespace APBD_Cw1_s30115.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Models.Equipment> _equipments = [];
    
    public void AddEquipment(Models.Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public List<Models.Equipment> GetAll()
    {
        return _equipments;
    }

    public List<Models.Equipment> GetAvailable()
    {
        List<Models.Equipment> Availables = new List<Models.Equipment>();
        foreach (var equipment in _equipments)
        {
            if (equipment.Status == EquipmentStatus.Available)
            {
                Availables.Add(equipment);
            }
        }

        return Availables;

    }

    public void DeleteEquipment(int equipmentId)
    {
        Models.Equipment equipmentToDelete = null;
        foreach (var eq in _equipments)
        {
            if (eq.ID == equipmentId)
            {
                equipmentToDelete = eq;
                break; 
            }
        }
        
        if (equipmentToDelete == null)
        {
            throw new EquipmentNotFoundException(equipmentId);
        }
        _equipments.Remove(equipmentToDelete);
    }

    public void SetStatusRented(int equipmentId)
    {
        var equipment = _equipments.FirstOrDefault(equipment => equipment.ID == equipmentId);
        if (equipment == null)
        {
            throw new EquipmentNotFoundException(equipmentId);
        }

        equipment.Status = EquipmentStatus.Rented;

    }

    public void SetStatusAvailable(int equipmentId)
    {
        var equipment = _equipments.FirstOrDefault(equipment => equipment.ID == equipmentId);
        if (equipment == null)
        {
            throw new EquipmentNotFoundException(equipmentId);
        }

        equipment.Status = EquipmentStatus.Available;
    }

    public void SetStatusMaintenance(int equipmentId)
    {
        var equipment = _equipments.FirstOrDefault(equipment => equipment.ID == equipmentId);
        if (equipment == null)
        {
            throw new EquipmentNotFoundException(equipmentId);
        }

        equipment.Status = EquipmentStatus.Maintenance;
    }
}