using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Sdk.ActivityCreation
{
    public class CustomActivity_AY_PolicyActionAddScheduleData : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}:8442";
    
    public string Jsonkeypath = "addScheduleData";
    
    public string password1 = "";
    
    public string newEntity = "";
    
    public string id_p = "";
    
    public string name_p = "";
    
    public string description = "";
    
    public string moduleID = "";
    
    public string workflowId = "";
    
    public string workflowName = "";
    
    public string startDate = "";
    
    public string endDate = "";
    
    public string actionData = "";
    
    public string Dates__ = "";
    
    public string Days__ = "";
    
    public string ScheduleType = "";
    
    public string BetweenFrom = "";
    
    public string BetweenTo = "";
    
    public string RunAt = "";
    
    public string Every = "";
    
    public string Date = "";
    
    public string nextRunDate = "";
    
    public string lastRunDate = "";
    
    public string deleteAfterLastRun = "";
    
    public string taskRunTimeLimit = "";
    
    public string skipTask = "";
    
    public string status = "";
    
    public string enabled = "";
    
    public string eventNumber = "";
    
    public string logit = "";
    
    public string creationDate = "";
    
    public string lastSaved = "";
    
    public string lastModifyById = "";
    
    public string savedBy = "";
    
    public string scheduleStatement = "";
    
    public string logCategoriesIds__ = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "POST";
    
    private string uriBuilderPath {
        get {
            return "Server/Api/policyAction/addScheduleData";
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"id\": \"{0}\",  \"name\": \"{1}\",  \"description\": \"{2}\",  \"moduleID\": \"{3}\",  \"workflowId\": \"{4}\",  \"workflowName\": \"{5}\",  \"startDate\": \"{6}\",  \"endDate\": \"{7}\",  \"actionData\": \"{8}\",  \"actionDataObj\": {{   \"ScheduleType\": \"{9}\",    \"BetweenFrom\": \"{10}\",    \"BetweenTo\": \"{11}\",    \"RunAt\": \"{12}\",    \"Every\": \"{13}\",    \"Date\": \"{14}\"   }},  \"nextRunDate\": \"{15}\",  \"lastRunDate\": \"{16}\",  \"deleteAfterLastRun\": \"{17}\",  \"taskRunTimeLimit\": \"{18}\",  \"skipTask\": \"{19}\",  \"status\": \"{20}\",  \"enabled\": \"{21}\",  \"eventNumber\": \"{22}\",  \"logit\": \"{23}\",  \"creationDate\": \"{24}\",  \"lastSaved\": \"{25}\",  \"lastModifyById\": \"{26}\",  \"savedBy\": \"{27}\",  \"scheduleStatement\": \"{28}\" }}",id_p,name_p,description,moduleID,workflowId,workflowName,startDate,endDate,actionData,ScheduleType,BetweenFrom,BetweenTo,RunAt,Every,Date,nextRunDate,lastRunDate,deleteAfterLastRun,taskRunTimeLimit,skipTask,status,enabled,eventNumber,logit,creationDate,lastSaved,lastModifyById,savedBy,scheduleStatement);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"authorization","Bearer " + password1}};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {};
        }
    }


        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {

            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint); 
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());
           
            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}