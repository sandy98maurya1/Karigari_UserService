using Contract;
using Contract.DataContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UsersDomain : IUsers
    {
        private readonly IUsersData _Users;
        public UsersDomain(IUsersData users)
        {
            _Users = users;
        }
        public bool AddUser(Users user)
        {
            _Users.AddUser(user);

            return true;
        }

        public bool DeleteUser(int userId)
        {
            _Users.DisableUser(userId);
            return true;
        }

        public IList<Users> GetAllUser()
        {
            var userList = _Users.GetAllUser();
            return userList;
        }

        public Users GetUserById(int userId)
        {
            var user= _Users.GetUserById(userId);
            return user;
        }

        public Users GetUserByName(string name)
        {
            var user = _Users.GetUserByName(name);
            return user;
        }

        public bool UpdateUser(Users user)
        {
            _Users.UpdateUser(user);
            return true;
        }
    }
}
