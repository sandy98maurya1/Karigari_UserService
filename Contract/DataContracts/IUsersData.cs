using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contract.DataContracts
{
    public interface IUsersData
    {
        bool AddUser(Users user);
        bool UpdateUser(Users user);
        bool DisableUser(int userId);
        IList<Users> GetAllUser();
        Users GetUserById(int userId);
        Users GetUserByName(string name);
    }
}
