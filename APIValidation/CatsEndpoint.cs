using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace APIValidation.APIValidation
{
    public class CatsEndpoint
    {
        private Uri uri;
        private string apiresponseCode;
        private string responseBody;
        internal void stroreEndpoint(string endpoint)
        {

             uri = new Uri(endpoint);

        }

        internal void requestAPIAsync()
        {



            RestClient client = new RestClient(uri);
          //  RestRequest request = new RestRequest("/facts", Method.Get);
            RestRequest request = new RestRequest("/facts", Method.Get);


            try
            {
                // Call the API endpoint and get the response
                RestResponse response = client.Execute(request);
                apiresponseCode=response.StatusCode.ToString();
                // Check if the response was successful
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Get the response content as a string
                     responseBody = response.Content;

                    // Do something with the response data
                    Console.WriteLine(responseBody);
                }
            }
            catch (Exception e)
            {
                // Handle any exceptions that occurred during the API call
                Console.WriteLine($"Error calling API: {e.Message}");
            }

        }
        internal void requestAPIfor(string userid)
        {



            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest($"/facts/{userid}", Method.Get);


            try
            {
                RestResponse response = client.Execute(request);
                apiresponseCode = response.StatusCode.ToString();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseBody = response.Content;

                    Console.WriteLine(responseBody);
                }
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Assert.Fail($"API is not responding recieved error code {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error calling API: {e.Message}");
            }

        }


        internal void validateResponseCode(string responseCode) {
        
                Assert.True(responseCode == apiresponseCode,$"Expected Reponse code : {responseCode} is not thrown but {apiresponseCode} code thrown");

        }

        internal void confirmUserResponse(string user)
        {


            Assert.True(responseBody.Contains(user), $"User {user} is not present in the response body");
                
        }

        internal void confirmUserReponseData(string id, string columnname, string value)
        {

            JObject json = JObject.Parse(responseBody);

     
            string ids = (string)json["_id"];
            string user = (string)json["user"]["_id"];
            string text = (string)json["text"];

            string firstName = (string)json["user"]["name"]["first"];
            string lastName = (string)json["user"]["name"]["last"];
            string type = (string)json["type"];


            Assert.True(id == ids,"ids are not matching");
            switch (columnname)
            {
                case "user":
                    Assert.True(user == value, $"user is not matching for {ids}");
                    break;

                case "text":
                    Assert.True(text == value, $"text is not matching for {ids}");
                    break;
                case "firstname":
                    Assert.True(firstName == value, $"firstname is not matching for {ids}");
                    break;
                case "lastname":
                    Assert.True(lastName == value, $"firstname is not matching for {ids}");
                    break;
                case "type":
                    Assert.True(type == value, $"firstname is not matching for {ids}");
                    break;

            }
  


        }
    }
}
