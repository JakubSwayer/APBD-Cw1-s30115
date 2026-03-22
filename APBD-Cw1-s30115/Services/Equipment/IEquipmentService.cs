using APBD_Cw1_s30115.Models;

namespace APBD_Cw1_s30115.Services.Equipment;

public interface IEquipmentService
{

    public void AddEquipment(Models.Equipment equipment);
    public Models.Equipment DeleteEquipment(int equipmentId);
    public List<Models.Equipment> GetAll();
    public List<Models.Equipment> GetAvailable();
    public void SetStatusAvailable(int equipmentId);
    public void SetStatusRented(int equipmentId);
}