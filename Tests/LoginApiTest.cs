using DemoNUnitProject.Models;
using DemoNUnitProject.Models.Request;
using DemoNUnitProject.Models.Response;
using DemoNUnitProject.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace DemoNUnitProject.Tests
{
    /*
     * LoginApiTest.cs
     * -------------------------------------------------------
     * Equivalent to Java LoginApiTest.java
     *
     * Purpose:
     * - Test Login API with valid credentials
     * - Send login request
     * - Deserialize response into LoginResponse object
     * - Validate status code and response data
     *
     * Java TestNG --> C# NUnit Conversion:
     * ---------------------------------------
     * @Test              → [Test]
     * Assert.assertEquals → Assert.That()
     * Assert.assertNotNull → Assert.IsNotNull()
     */

    [TestFixture]
    internal class LoginApiTest
    {
        /*
         * Test Method:
         * Valid Login Test
         */
        [Test]
        public void LoginTest()
        {
            /*
             * Step 1: Create Login Request Payload Object
             * ---------------------------------------------
             * POCO object in C# equivalent to Java POJO
             */
            LoginRequest loginRequest = new LoginRequest(
                "aks.igec@gmail.com",
                "Kripalukunj@99"
            );

            /*
             * Step 2: Create AuthService Object
             */
            AuthService authService = new AuthService();

            /*
             * Step 3: Call Login API
             */
            RestResponse response = authService.Login(loginRequest);

            /*
             * Step 4: Print Raw Response
             */
            Console.WriteLine("Response Body => ");
            Console.WriteLine(response.Content);

            /*
             * Step 5: Deserialize JSON Response
             * ---------------------------------------------
             * Convert JSON into LoginResponse object
             */
            LoginResponse loginResponse =
                JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            /*
             * Step 6: Print Important Fields
             */
            Console.WriteLine("Token => " + loginResponse.Token);

            foreach (var role in loginResponse.Roles)
            {
                Console.WriteLine("Role => " + role);
            }

            Console.WriteLine("Username => " + loginResponse.Username);
            Console.WriteLine("Email => " + loginResponse.Email);
            Console.WriteLine("ID => " + loginResponse.Id);

            /*
             * Step 7: Assertions
             */

            // Validate status code
            Assert.That((int)response.StatusCode, Is.EqualTo(200),
                "Expected status code should be 200");

            // Validate token is not null
            Assert.IsNotNull(loginResponse.Token,
                "Token should not be null");

            // Validate username
            Assert.That(loginResponse.Username,
                Is.EqualTo("aks.igec@gmail.com"),
                "Username should match request");

            // Validate email
            Assert.That(loginResponse.Email,
                Is.EqualTo("aks.igec@gmail.com"),
                "Email should match request");
        }
    }
}