using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public interface IUsers
    {
        bool AddUser(Users user);
        bool UpdateUser(Users user);
        bool DeleteUser(int userId);
        IList<Users> GetAllUser();
        Users GetUserById(int userId);
        Users GetUserByName(string name);   
    }
}
