using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

namespace APBD_Cw1_s30115.Services.Rental;

public class RentalService : IRentalService
{

    private readonly List<Models.Rental> _rentals = [];

    public void CreateRental(User user, Models.Equipment equipment, DateTime from, DateTime to)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentNotAvailableException(equipment.ID);
        }

        Models.Rental rental = new Models.Rental(user, equipment, from, to);
        equipment.Status = EquipmentStatus.Rented;
        _rentals.Add(rental);
        
    }

    public List<Models.Rental> GetAll()
    {
        return _rentals;
    }

    public void EndRental(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId);
        if (rental == null)
        {
            throw new RentalNotFoundException(rentalId);
        }

        rental.Equipment.Status = EquipmentStatus.Available;
        
        _rentals.Remove(rental);
    }

    public List<Models.Rental> GetUserReservations(User user)
    {
        List<Models.Rental> userRentals = [];
        foreach (var rental in _rentals)
        {
            if (rental.User == user)
            {
                userRentals.Add(rental);
            }
        }

        if (userRentals.Count == 0)
        {
            Console.Write($"Warning: User with provided ID: {user.ID} has no rentals!");
        }

        return userRentals;

    }
}