﻿using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SearchDomain : ISearch
    {
        private readonly ISearchData _searchData;
        public SearchDomain(ISearchData searchData)
        {
            _searchData = searchData;
        }

        public IEnumerable<Search> GetCompanyByJobType(string JobType)
        {
            return _searchData.GetCompanyByJobType(JobType);
        }

        public IEnumerable<Search> GetCompanyByLocation(string JobType, string Location)
        {
            return _searchData.GetCompanyByLocation(JobType,Location);
        }
    }
}
