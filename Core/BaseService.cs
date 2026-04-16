using System;
using RestSharp;

namespace DemoNUnitProject.Core
{
    /*
     * BaseService.cs
     * -------------------------------------------------------
     * This class is wrapper around RestSharp API calls.
     *
     * Purpose:
     * - Keep all common API methods in one place
     * - Reuse GET, POST, PUT requests
     * - Maintain common Base URL
     * - Support Authorization token handling
     * - Make framework scalable and maintainable
     */

    internal class BaseService
    {
        // Common Base URL for all APIs
        private const string BASE_URI = "http://64.227.160.186:8080";

        // RestSharp client object
        protected RestClient client;

        /*
         * Constructor
         * ------------------------------------
         * Initializes RestClient with Base URL
         */
        public BaseService()
        {
            client = new RestClient(BASE_URI);
        }

        /*
         * POST Request Method
         * ------------------------------------
         * Sends POST request with JSON body
         */
        protected RestResponse PostRequest(object payload, string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(payload);

            return client.Execute(request);
        }

        /*
         * PUT Request Method
         * ------------------------------------
         * Sends PUT request with JSON body
         */
        protected RestResponse PutRequest(object payload, string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(payload);

            return client.Execute(request);
        }

        /*
         * GET Request Method
         * ------------------------------------
         * Sends GET request
         */
        protected RestResponse GetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);

            return client.Execute(request);
        }

        /*
         * Set Authorization Token
         * ------------------------------------
         * Adds Bearer token in request header
         */
        protected void SetAuthToken(RestRequest request, string token)
        {
            request.AddHeader("Authorization", "Bearer " + token);
        }

        /*
         * POST Request with Base URL Override
         * ------------------------------------
         * If any API uses different base URL,
         * this method overrides default base URI
         */
        protected RestResponse PostRequest(string baseUrl, object payload, string endpoint)
        {
            var overrideClient = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(payload);

            return overrideClient.Execute(request);
        }
    }
}