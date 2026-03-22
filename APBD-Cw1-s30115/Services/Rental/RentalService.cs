using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

namespace APBD_Cw1_s30115.Services.Rental;

public class RentalService : IRentalService
{

    private List<Models.Rental> _rentals = [];

    public void CreateRental(User user, Models.Equipment equipment, DateTime from, DateTime to)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentNotAvailableException()
        }
        
    }
}