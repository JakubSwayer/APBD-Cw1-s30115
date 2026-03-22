using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

namespace APBD_Cw1_s30115.Services.Rental;

public interface IRentalService
{
    public void CreateRental(User user, Models.Equipment equipment, DateTime from, DateTime to);
    public void EndRental(int rentalId);
    public List<Models.Rental> GetUserReservations(User user);
    public List<Models.Rental> GetAll();
}