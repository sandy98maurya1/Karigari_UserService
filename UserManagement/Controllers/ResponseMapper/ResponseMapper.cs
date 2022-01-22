using Models;
using System;
using System.Collections.Generic;
using Utility;

namespace UserManagement.Controllers.ResponseMapper
{
    public static class ResponseMapper
    {
        public static ApiListResponse<IList<Users>> GetUsersResponce(this IList<Users> users)
        {
            return new ApiListResponse<IList<Users>>
            {
                Message = string.Format(ErrorMessages.Success),
                IsSuccess = true,
                Data = users,
                StatusCode = 200
            };
        }
        public static ApiListResponse<Users> GetUserResponce(this Users users)
        {
            return new ApiListResponse<Users>
            {
                Message = string.Format(ErrorMessages.Success),
                IsSuccess = true,
                Data = users,
                StatusCode = 200
            };
        }
        public static ApiResponse<Users> CreateProfileResponse(this bool status, Users user)
        {
            if (status)
            {
                return new ApiResponse<Users>
                {
                    Message = string.Format(ErrorMessages.CreateSucess, user.FirstName + " " + user.LastName),
                    IsSuccess = status,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<Users>
                {
                    Message = string.Format(ErrorMessages.CreateFail, user.FirstName + " " + user.LastName),
                    IsSuccess = status,
                    StatusCode = 400
                };
            }
        }
        public static ApiResponse<Users> DisableProfileResponse(this bool status)
        {
            if (status)
            {
                return new ApiResponse<Users>
                {
                    Message = string.Format(ErrorMessages.DeleteSucess, "Profile"),
                    IsSuccess = status,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<Users>
                {
                    Message = string.Format(ErrorMessages.DeleteFail, "Profile"),
                    IsSuccess = status,
                    StatusCode = 400
                };
            }
        }
        public static ApiResponse<Users> CacheExceptionResponse(this Exception ex)
        {
            return new ApiResponse<Users>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }
        public static ApiResponse<IList<Users>> CacheListExceptionResponse(this Exception ex)
        {
            return new ApiListResponse<IList<Users>>
            {
                IsSuccess = false,
                Data = null,
                Message = ex.Message
            };
        }
    }
}
