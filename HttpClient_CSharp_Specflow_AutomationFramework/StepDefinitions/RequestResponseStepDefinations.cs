using HttpClient_CSharp_Specflow_AutomationFramework.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System.Xml.Linq;
using TechTalk.SpecFlow.Infrastructure;

namespace HttpClient_CSharp_Specflow_AutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class RequestResponseStepDefinations
    {
        HttpClient httpClient;
        HttpResponseMessage httpResponse;
        ISpecFlowOutputHelper outputHelper;
        string responseBody;

        /// <summary>
        /// Constructor
        /// </summary>
        public RequestResponseStepDefinations(ISpecFlowOutputHelper outputHelper) 
        {
            httpClient = new HttpClient();
            this.outputHelper = outputHelper;       
        }

        [Given(@"the user sends a get request with url as '([^']*)'")]
        public async Task GivenTheUserSendsAGetRequestWithUrlAs(string url)
        {
             httpResponse = await httpClient.GetAsync(url);
            responseBody = await httpResponse.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ReqResModel>(responseBody);
        }

        [Then(@"I verify the response code is '([^']*)'")]
        public void ThenIVerifyTheResponseCodeIs(string p0)
        {
            Assert.True(httpResponse.IsSuccessStatusCode);
        }

        [Given(@"the user sends a post request with url as '([^']*)'")]
        public async Task GivenTheUserSendsAPostRequestWithUrlAs(string url)
        {
            RequestModel requestModel = new RequestModel()
            {
                name = "harsh",
                job = "Automation Test Enginner"
            };

            var data = JsonConvert.SerializeObject(requestModel);
            var contentdata = new StringContent(data);
            httpResponse = await httpClient.PostAsync(url, contentdata);
            responseBody = await httpResponse.Content.ReadAsStringAsync();
            outputHelper.WriteLine(responseBody);
        }




    }
}
