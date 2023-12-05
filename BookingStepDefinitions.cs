using System;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
using System.Security.Policy;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class BookingStepDefinitions
    {
        
        public RestClient client = new RestClient();
        public RestRequest request = new RestRequest();
        public RestResponse response = new RestResponse();


        [When(@"I send a POST request to ""([^""]*)"" with details ""([^""]*)"" and ""([^""]*)""")]
        public void WhenISendAPOSTRequestToWithDetailsAnd(string url, string admin, string password_value)
        {
            client = new RestClient(url);
            request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Method = Method.Post;
            var requestBody = new
            {
                username = admin,
                password = password_value
            };
            request.AddJsonBody(requestBody);
            response = client.Execute(request);
        }

        [Then(@"the response status code should (.*)")]
        public void ThenTheResponseStatusCodeShould(int responceCode)
        {
            Assert.AreEqual(responceCode, Convert.ToInt32(response.StatusCode));
        }

        [When(@"I send a GET request to ""([^""]*)""")]
        public void WhenISendAGETRequestTo(string url)
        {
            client = new RestClient(url);
            request = new RestRequest();
            request.Method = Method.Get;
            response = client.Execute(request);
        }

        [When(@"I send a POST request to ""([^""]*)"" with details: (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenISendAPOSTRequestToWithDetailsAnnaBilousFalseBreakfast(string url, string firstname_value, string lastname_value, string totalprice_value, string depositpaid_value, string checkin_value, string checkout_value, string additionalneeds_value)
        {
            
            client = new RestClient(url);
            request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.Method = Method.Post;
            var requestBody = new
            {
                firstname = firstname_value,
                lastname = lastname_value,
                totalprice = totalprice_value,
                depositpaid = depositpaid_value,
                bookingdates = new
                {
                    checkin = checkin_value,
                    checkout = checkout_value
                },
                additionalneeds = additionalneeds_value
            };
            request.AddJsonBody(requestBody);
            response = client.Execute(request);
        }

        [When(@"I send a PUT request to ""([^""]*)"" with details:(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenISendAPUTRequestToWithDetailsAnnaBilousTrueBreakfast(string url,string id, string firstname_value, string lastname_value, string totalprice_value, string depositpaid_value, string checkin_value, string checkout_value, string additionalneeds_value)
        {
            
            client = new RestClient(url.Replace(":id",id));
            request = new RestRequest();
            request.Method = Method.Put;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");//авторизація
            
            var requestBody = new
            {
                firstname = firstname_value,
                lastname = lastname_value,
                totalprice = totalprice_value,
                depositpaid = depositpaid_value,
                bookingdates = new
                {
                    checkin = checkin_value,
                    checkout = checkout_value
                },
                additionalneeds = additionalneeds_value
            };
            request.AddJsonBody(requestBody);
            response = client.Execute(request);

        }

        [When(@"I send a DELETE request to ""([^""]*)"" with details: (.*)")]
        public void WhenISendADELETERequestToWithDetails(string url, int id)
        {
            client = new RestClient(url.Replace(":id", id.ToString()));
            request = new RestRequest();
            request.Method = Method.Delete;
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            response = client.Execute(request);
        }





































    }
}
