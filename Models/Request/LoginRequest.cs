using System;

namespace DemoNUnitProject.Models.Request
{
    /*
     * LoginRequest.cs
     * -------------------------------------------------------
     * This class represents Login Request Payload.
     *
     * Purpose:
     * - Store username and password
     * - Send request body to Login API
     *
     * Example JSON Payload:
     * {
     *   "username": "uday1234",
     *   "password": "uday12345"
     * }
     */

    internal class LoginRequest
    {
        /*
         * Properties
         * ---------------------------------------
         * These map to API JSON request fields
         */
        public string Username { get; set; }
        public string Password { get; set; }

        /*
         * Constructor
         * ---------------------------------------
         * Used to initialize LoginRequest object
         */
        public LoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /*
         * Override ToString()
         * ---------------------------------------
         * Helps in logging/debugging
         *
         * Default object print:
         * DemoNUnitProject.Models.LoginRequest
         *
         * After override:
         * LoginRequest [Username=abc, Password=xyz]
         */
        public override string ToString()
        {
            return $"LoginRequest [Username={Username}, Password={Password}]";
        }
    }
}