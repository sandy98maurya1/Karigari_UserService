using Contract.DataContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProfileRepository : IProfileData
    {
        public JobProfile CreateUserJobProfile(JobProfile profile)
        {
            throw new NotImplementedException();
        }

        public JobProfile GetProfileByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public JobProfile UpdateUserJobProfile(JobProfile profile, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
