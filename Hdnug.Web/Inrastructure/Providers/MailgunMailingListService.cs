using Hdnug.Web.Inrastructure.Interfaces;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hdnug.Web.Inrastructure.Providers
{
    public class MailgunMailingListService : IMailingListService
    {
        private readonly string apiKey;
        private readonly string domain;
        private readonly string apiPath;

        public MailgunMailingListService()
        {
            this.apiPath = "https://api.mailgun.net/v3";
            this.apiKey = "YOUR_API_KEY";
            this.domain = "hdnug.org";
        }

        private RestClient BuildClient()
        {
            var client = new RestClient(this.apiPath) {
                Authenticator = new HttpBasicAuthenticator("api", this.apiKey)
            };

            return client;
        }

        public void AddMember(string listname, string firstname, string lastname, string company, string email)
        {
            var client = BuildClient();
            var request = new RestRequest("lists/{list}/members", Method.POST);
            request.AddParameter("list", $"{listname}@{domain}", ParameterType.UrlSegment);
            request.AddObject(new
            {
                subscribed = true,
                address = "bar@example.com",
                name = "Bob Bar",
                description = "Developer",
                vars = "{'age': 26}"
            });

            var response = client.Execute(request);
        }
    }
}
