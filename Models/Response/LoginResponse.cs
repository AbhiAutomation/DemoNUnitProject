using System;
using System.Collections.Generic;

namespace DemoNUnitProject.Models.Response
{
    /*
     * LoginResponse.cs
     * -------------------------------------------------------
     * This class represents Login API Response Payload.
     *
     * Equivalent to Java LoginResponse.java
     *
     * Purpose:
     * - Capture response returned after successful login
     * - Store token, user info, roles
     *
     * Example JSON Response:
     * {
     *   "token": "eyJhbGciOiJIUzI1NiIs...",
     *   "type": "Bearer",
     *   "id": 1,
     *   "username": "uday1234",
     *   "email": "uday@test.com",
     *   "roles": ["ROLE_USER"]
     * }
     */

    internal class LoginResponse
    {
        /*
         * Properties
         * ---------------------------------------
         * These map directly to response JSON fields
         */

        public string Token { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        /*
         * Default Constructor
         */
        public LoginResponse()
        {
        }

        /*
         * Parameterized Constructor
         */
        public LoginResponse(
            string token,
            string type,
            int id,
            string username,
            string email,
            List<string> roles)
        {
            Token = token;
            Type = type;
            Id = id;
            Username = username;
            Email = email;
            Roles = roles;
        }

        /*
         * Override ToString()
         * ---------------------------------------
         * Helps in debugging/logging readable output
         */
        public override string ToString()
        {
            return $"LoginResponse [Token={Token}, Type={Type}, Id={Id}, Username={Username}, Email={Email}, Roles={string.Join(",", Roles ?? new List<string>())}]";
        }
    }
}