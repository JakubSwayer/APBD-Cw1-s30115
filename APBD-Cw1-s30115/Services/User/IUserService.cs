using APBD_Cw1_s30115.Models;

namespace APBD_Cw1_s30115.Services.User;

public interface IUserService
{
    public void AddUser(Models.User user);
    public List<Models.User> GetAll();
    public Models.User GetUserById(int id);
}