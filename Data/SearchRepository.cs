using Contract;
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
                    var query = @"SELECT c.Id,	cj.Duration,	cj.JobAvailableDate,	j.jobName as JobType, l.Name as Location	
                                ,cj.IsAccomodation	,cj.NoOfPositions	,c.CompanyName, c.BusinessContactNo as ContactNo
                                FROM Company_Job_Post cj 
                                inner join JobType j 
                                on cj.JobTypeID = j.Id
                                inner join Location_State l
                                on cj.LocationID = l.Id
                                inner join Company c 
                                on cj.companyId = c.Id
                                WHERE JobTypeID = @JobType"; 
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
                    var query = @"SELECT c.Id,	cj.Duration,	cj.JobAvailableDate,	j.jobName as JobType, l.Name as Location	
                                ,cj.IsAccomodation	,cj.NoOfPositions	,c.CompanyName, c.BusinessContactNo as ContactNo 
                                FROM Company_Job_Post cj 
                                inner join JobType j 
                                on cj.JobTypeID = j.Id
                                inner join Location_State l
                                on cj.LocationID = l.Id
                                inner join Company c 
                                on cj.companyId = c.Id
                                WHERE JobTypeID = @JobType AND Location =@Location";
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
