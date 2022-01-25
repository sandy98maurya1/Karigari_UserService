using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public interface ISearchData
    {
        IEnumerable<Search> GetCompanyByJobType(string JobType);
        IEnumerable<Search> GetCompanyByLocation(string JobType, string Location);
    }
}
