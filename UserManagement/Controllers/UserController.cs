﻿using Contract;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using Utility;
using Utility.LoggerService;
using UserManagement.Controllers.ResponseMapper;


namespace UserManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUsers _userDomain;
        private readonly ILoggerManager _logger;
        public UserController(IUsers user, ILoggerManager logger)
        {
            _userDomain = user;
            _logger = logger;
        }

        [HttpGet, Route("/GetUsers")]
        public IActionResult GetUsers()
        {
            ApiResponse<IList<Users>> responce = new ApiResponse<IList<Users>>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.GetAllUser().GetUsersResponce();
            }
            catch (Exception ex)
            {
                responce = ex.CacheListExceptionResponse();
            }
            return Ok(responce);

        }

        [HttpGet, Route("/GetUsersById")]
        public IActionResult GetUsersById(int id)
        {
            ApiResponse<Users> responce = new ApiResponse<Users>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.GetUserById(id).GetUserResponce();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
            }
            return Ok(responce);
        }

        [HttpGet, Route("/GetUsersByName")]
        public ActionResult GetUsersByName(string name)
        {
            ApiResponse<Users> responce = new ApiResponse<Users>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.GetUserByName(name).GetUserResponce();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
            }
            return Ok(responce);
        }

        [HttpPost, Route("/AddUser")]
        public ActionResult AddUser(Users users)
        {
            ApiResponse<Users> responce = new ApiResponse<Users>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.AddUser(users).CreateProfileResponse(users);
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
            }
            return Ok(responce);
        }

        [HttpPost, Route("/UpdateUser")]
        public ActionResult UpdateUser(Users users)
        {
            ApiResponse<Users> responce = new ApiResponse<Users>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.AddUser(users).CreateProfileResponse(users);
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
            }
            return Ok(responce);
        }

        [HttpPost, Route("/DeleteUser")]
        public ActionResult DeleteUser(int userId)
        {
            ApiResponse<Users> responce = new ApiResponse<Users>();
            try
            {
                ApiExposeResponse<Dictionary<string, string>> modelErrors = GetModelErrors();
                responce = _userDomain.DeleteUser(userId).DisableProfileResponse();
            }
            catch (Exception ex)
            {
                responce = ex.CacheExceptionResponse();
            }
            return Ok(responce);
        }
        private ApiExposeResponse<Dictionary<string, string>> GetModelErrors()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    string errordetails = string.Empty;
                    foreach (var error in state.Value.Errors)
                    {
                        errordetails = errordetails + error.ErrorMessage;
                    }

                    errors.Add(state.Key.Contains(".") ? state.Key.Split('.')[1] : state.Key, errordetails);
                }
            }


            return new ApiExposeResponse<Dictionary<string, string>>
            {
                IsSuccess = false,
                Message = ErrorMessages.InValidInputMsg,
                Error = errors
            };
        }
    }
}