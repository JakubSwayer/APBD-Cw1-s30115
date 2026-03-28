using APBD_Cw1_s30115.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APBD_Cw1_s30115.Services.User;

public class UserService : IUserService
{
    private readonly List<Models.User> _users = [];

    public void AddUser(Models.User user)
    {
        _users.Add(user);
    }

    public List<Models.User> GetAll()
    {
        return _users;
    }

    public Models.User GetUserById(int id)
    {
        var user = _users.FirstOrDefault(u => u.ID == id);
        if (user == null)
        {
            throw new Exception($"User with ID {id} not found.");
        }
        return user;
    }
}