﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public interface IUsers
    {
        bool AddUser(Users user);
        bool UpdateUser(Users user, int id);
        bool DeleteUser(int userId);
        IList<Users> GetAllUser();
        Users GetUserById(int userId);
        Users GetUserByName(string name);
        IList<TalukaDetails> GetTalukaDetails(int divisionId);
        IList<DivisionDetails> GetDivisionDetails(int stateId);
        IList<StateDetails> GetStateDetails(int countryId);
    }
}
