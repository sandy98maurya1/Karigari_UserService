using Contract;
using Contract.DataContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProfileDomain : IProfile
    {
        private readonly IProfileData _Profile;
        public ProfileDomain(IProfileData profile)
        {
            _Profile = profile;
        }
        public JobProfile CreateUserJobProfile(JobProfile profile)
        {
           return _Profile.CreateUserJobProfile(profile);
        }

        public JobProfile GetProfileByUserId(int userId)
        {
            return _Profile.GetProfileByUserId(userId);

        }

        public JobProfile UpdateUserJobProfile(JobProfile profile, int userId)
        {
            return _Profile.UpdateUserJobProfile(profile,userId);

        }
    }
}
