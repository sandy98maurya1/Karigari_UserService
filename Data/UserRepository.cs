﻿using Contract.DataContracts;
using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public class UserRepository : IUsersData
    {
        IConfiguration _configuration;
        internal string connection { get; set; }
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = GetConnection();
        }
        public IList<Users> GetAllUser()
        {
            List<Users> products = new List<Users>();

            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @"SELECT U.Id,U.FirstName,U.LastName,U.Contact,U.AlternetContact,U.MaritalStatus,U.Gender,U.DateOfBirth,U.Role,U.WorkerType,U.IsActive," +
                        "U.RefreshToken,U.Password,U.IsMobileVerified,U.DeviceID,A.Id as UserId, A.Village,A.Taluka,A.City,A.State,A.Country,A.Zip FROM Users U, " +
                        "Address A  where U.ID = A.UserId";
                    products = dbConnection.Query<Users, Address, Users>(query, MapResults, splitOn: "UserId").ToList();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return products;
            }
        }
        public Users GetUserById(int userId)
        {
            Users user = new Users();
            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @"SELECT U.Id,U.FirstName,U.LastName,U.Contact,U.AlternetContact,U.MaritalStatus,U.Gender,U.DateOfBirth,U.Role,U.WorkerType,U.IsActive," +
                        "U.RefreshToken,U.Password,U.IsMobileVerified,U.DeviceID,A.Id as UserId, A.Village,A.Taluka,A.City,A.State,A.Country,A.Zip FROM Users U, " +
                        "Address A  where U.ID = A.UserId and U.ID = @id";

                    user = (Users)dbConnection.Query<Users, Address, Users>(query, MapResults, new { @id = userId }, splitOn: "UserId");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return user;
            }
        }
        public Users GetUserByName(string name)
        {
            Users user = new Users();
            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @"SELECT U.Id,U.FirstName,U.LastName,U.Contact,U.AlternetContact,U.MaritalStatus,U.Gender,U.DateOfBirth,U.Role,U.WorkerType,U.IsActive," +
                        "U.RefreshToken,U.Password,U.IsMobileVerified,U.DeviceID,A.Id as UserId, A.Village,A.Taluka,A.City,A.State,A.Country,A.Zip FROM Users U, " +
                        "Address A  where U.ID = A.UserId and U.FirstName = @name";

                    user = (Users)dbConnection.Query<Users, Address, Users>(query, MapResults, new { @name = name }, splitOn: "UserId");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return user;
            }
        }
        public bool AddUser(Users user)
        {
            int count = 0;
            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();

                    using (var transaction = dbConnection.BeginTransaction())
                    {

                        var userId = dbConnection.Query<int>(@"INSERT INTO Users(FirstName,LastName,Contact,AlternetContact,MaritalStatus,Gender,Address,Role,WorkerType,IsActive,RefreshToken,Password,IsMobileVerified,DeviceID,Enabled) VALUES (@FirstName,@LastName,@Contact,@AlternetContact,@MaritalStatus,@Gender,@Address,@Role,@WorkerType,@IsActive,@RefreshToken,@Password,@IsMobileVerified,@DeviceID,@Enabled); SELECT CAST(SCOPE_IDENTITY() as INT);",
                        new { @FirstName = user.FirstName, @LastName = user.LastName, @Contact = user.Contact, @AlternetContact = user.AlternetContact, @MaritalStatus = user.MaritalStatus, @Gender = user.Gender, @Address = user.Address, @Role = user.Role, @WorkerType = user.WorkerType, @IsActive = user.IsActive, @RefreshToken = user.RefreshToken, @Password = user.Password, @IsMobileVerified = user.IsMobileVerified, @DeviceID = user.DeviceID, @Enabled = user.Enabled }, transaction: transaction).FirstOrDefault();
                        if (user.Address != null && userId != 0)
                        {
                            count = dbConnection.Execute(@"INSERT INTO Address(UserId,Village, Taluka, City, State, Country, Zip) 
                            VALUES(@UserId,@Village, @Taluka, @City, @State, @Country, @Zip);",
                            new { @UserId = userId, @Village = user.Address.Village, @Taluka = user.Address.Taluka, @City = user.Address.City, @State = user.Address.State, @Country = user.Address.Country, @Zip = user.Address.Zip }, transaction: transaction);
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return count == 1 ? true : false;
            }
        }
        public bool UpdateUser(Users user)
        {
            int count = 0;
            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();

                    using (var transaction = dbConnection.BeginTransaction())
                    {

                        var userId = dbConnection.Query<int>(@"INSERT INTO Users(FirstName,LastName,Contact,AlternetContact,MaritalStatus,Gender,Address,Role,WorkerType,IsActive,RefreshToken,Password,IsMobileVerified,DeviceID,Enabled) VALUES (@FirstName,@LastName,@Contact,@AlternetContact,@MaritalStatus,@Gender,@Address,@Role,@WorkerType,@IsActive,@RefreshToken,@Password,@IsMobileVerified,@DeviceID,@Enabled); SELECT CAST(SCOPE_IDENTITY() as INT);",
                        new { @FirstName = user.FirstName, @LastName = user.LastName, @Contact = user.Contact, @AlternetContact = user.AlternetContact, @MaritalStatus = user.MaritalStatus, @Gender = user.Gender, @Address = user.Address, @Role = user.Role, @WorkerType = user.WorkerType, @IsActive = user.IsActive, @RefreshToken = user.RefreshToken, @Password = user.Password, @IsMobileVerified = user.IsMobileVerified, @DeviceID = user.DeviceID, @Enabled = user.Enabled }, transaction: transaction).FirstOrDefault();
                        if (user.Address != null && userId != 0)
                        {
                            count = dbConnection.Execute(@"INSERT INTO Address(UserId,Village, Taluka, City, State, Country, Zip) 
                            VALUES(@UserId,@Village, @Taluka, @City, @State, @Country, @Zip);",
                            new { @UserId = userId, @Village = user.Address.Village, @Taluka = user.Address.Taluka, @City = user.Address.City, @State = user.Address.State, @Country = user.Address.Country, @Zip = user.Address.Zip }, transaction: transaction);
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return count == 1 ? true : false;
            }
        }
        public bool DisableUser(int userId)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "update Users set Enabled=0 WHERE Id =@Id";
                    count = con.Execute(query, new { @Id = userId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count == 1 ? true : false;
            }
        }
        private Users MapResults(Users user, Address address)
        {
            user.Address = address;
            return user;
        }
        public string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }
    }
}