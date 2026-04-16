using System.Collections.Generic;
using RestSharp;
using DemoNUnitProject.Core;
using DemoNUnitProject.Models;

namespace DemoNUnitProject.Services
{
    /*
     * AuthService.cs
     * -------------------------------------------------------
     * This class handles Authentication APIs.
     *
     * Purpose:
     * - Login user
     * - Signup new user
     * - Forgot password request
     *
     * This class inherits BaseService,
     * so it can reuse common HTTP methods:
     * PostRequest(), GetRequest(), PutRequest()
     */

    internal class AuthService : BaseService
    {
        // Common Auth API base path
        private const string BASE_PATH = "/api/auth/";

        /*
         * Login API
         * ---------------------------------------
         * Endpoint:
         * POST /api/auth/login
         */
        public RestResponse Login(Models.Request.LoginRequest payload)
        {
            return PostRequest(payload, BASE_PATH + "login");
        }

        /*
         * Signup API
         * ---------------------------------------
         * Endpoint:
         * POST /api/auth/signup
         */
        //public RestResponse Signup(SignUpRequest signUpRequest)
        //{
        //    return PostRequest(signUpRequest, BASE_PATH + "signup");
        //}

        /*
         * Forgot Password API
         * ---------------------------------------
         * Endpoint:
         * POST /api/auth/forgot-password
         */
        public RestResponse Forgot(string emailAddress)
        {
            var payload = new Dictionary<string, string>
            {
                { "email", emailAddress }
            };

            return PostRequest(payload, BASE_PATH + "forgot-password");
        }
    }
}