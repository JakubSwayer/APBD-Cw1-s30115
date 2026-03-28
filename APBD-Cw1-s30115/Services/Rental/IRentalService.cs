using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

namespace APBD_Cw1_s30115.Services.Rental;

public interface IRentalService
{
    public void CreateRental(Models.User user, Models.Equipment equipment, DateTime from, DateTime to);
    public void FinishRental(int rentalId, DateTime returnDay);
    public List<Models.Rental> GetUserReservations(Models.User user);
    public List<Models.Rental> GetOverdueRentals(DateTime currentDate);
    public List<Models.Rental> GetAll();
}