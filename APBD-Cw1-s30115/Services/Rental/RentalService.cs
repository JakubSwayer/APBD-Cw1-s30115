using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

namespace APBD_Cw1_s30115.Services.Rental;

public class RentalService : IRentalService
{

    private readonly List<Models.Rental> _rentals = [];

    public void CreateRental(Models.User user, Models.Equipment equipment, DateTime from, DateTime to)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentNotAvailableException(equipment.ID);
        }
        
        int activeRentals = _rentals.Count(r => r.User.ID == user.ID && r.Status == RentalStatus.Ongoing);
        if (activeRentals >= user.GetMaxReservations())
        {
            throw new LimitExceededException(user.ID, user.GetMaxReservations());
        }

        Models.Rental rental = new Models.Rental(user, equipment, from, to);
        equipment.Status = EquipmentStatus.Rented;
        _rentals.Add(rental);
        
    }

    public List<Models.Rental> GetAll()
    {
        return _rentals;
    }

    public void FinishRental(int rentalId, DateTime returnDay)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.Id == rentalId);
        if (rental == null)
        {
            throw new RentalNotFoundException(rentalId);
        }
        
        if (rental.Status == RentalStatus.Finished)
        {
            Console.WriteLine($"Rental {rentalId} is already finished.");
            return;
        }

        if (returnDay > rental.To)
        {
            TimeSpan difference = returnDay - rental.To;
            int days = difference.Days;
            
            rental.FineAmount = days * Models.Rental.DelayFinePerDayUSD;
            Console.WriteLine($"Delay fee amounts to {rental.FineAmount} USD");
        }

        rental.Equipment.Status = EquipmentStatus.Available;
        rental.ActualReturnDate = returnDay;
        rental.Status = RentalStatus.Finished;
        
    }

    public List<Models.Rental> GetUserReservations(Models.User user)
    {
        List<Models.Rental> userRentals = [];
        foreach (var rental in _rentals)
        {
            if (rental.User == user && rental.Status == RentalStatus.Ongoing)
            {
                userRentals.Add(rental);
            }
        }

        if (userRentals.Count == 0)
        {
            throw new UserHasNoRentalsException(user.ID);
        }

        return userRentals;

    }
    public List<Models.Rental> GetOverdueRentals(DateTime currentDate)
    {
        List<Models.Rental> overdueRentals = [];
        
        foreach (var rental in _rentals)
        {
            // Sprawdzamy, czy wypożyczenie nadal trwa i czy termin zwrotu minął
            if (rental.Status == RentalStatus.Ongoing && rental.To < currentDate)
            {
                overdueRentals.Add(rental);
            }
        }

        return overdueRentals;
    }
    
}