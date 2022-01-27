﻿using Contract;
using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data
{
    public class SearchRepository : ISearchData
    {
        IConfiguration _configuration;
        internal string connection { get; set; }
        public object MapResults { get; private set; }

        public SearchRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = GetConnection();
        }

        public IEnumerable<Search> GetCompanyByJobType(int JobType)
        {
            IEnumerable<Search> result;

            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @"SELECT Id,	Duration,	JobAvailableDate,	JobTypeID,	LocationID	,IsAccomodation	,NoOfPositions	,CompanyId 
                                    FROM Company_Job_Post WHERE JobTypeID = @JobType"; 
                    result = (IEnumerable<Search>)dbConnection.Query<IEnumerable<Search>>(query, new { @JobType = JobType }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return result;
            }
        }

        public IEnumerable<Search> GetCompanyByLocation(int JobType, int Location)
        {
            IEnumerable<Search> result;

            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    var query = @"SELECT Id,	Duration,	JobAvailableDate,	JobTypeID,	LocationID	,IsAccomodation	,NoOfPositions	,CompanyId 
                                    FROM Company_Job_Post WHERE JobTypeID = @JobType AND Location =@Location";
                    result = (IEnumerable<Search>)dbConnection.Query<IEnumerable<Search>>(query, new { @JobType = JobType, @Location = Location }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return result;
            }
        }

        public string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }
    }
}
