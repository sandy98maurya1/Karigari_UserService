using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class SearchRepository : ISearchData
    {
        public IEnumerable<Search> GetCompanyByJobType(string JobType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Search> GetCompanyByLocation(string JobType, string Location)
        {
            throw new NotImplementedException();
        }
    }
}
