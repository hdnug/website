using Hdnug.Web.Inrastructure.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

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
            this.domain = "YOUR_MAILGUN_DOMAIN";
        }

        private RestClient BuildClient()
        {
            var client = new RestClient(this.apiPath) {
                Authenticator = new HttpBasicAuthenticator("api", this.apiKey)
            };

            return client;
        }

        public void AddMember(string listname, string email)
        {
            var client = BuildClient();
            var request = new RestRequest("lists/{list}/members", Method.POST);
            request.AddParameter("list", $"{listname}@{domain}", ParameterType.UrlSegment);
            request.AddObject(new
            {
                subscribed = true,
                address = email,
                upsert = true
            });

            var response = client.Execute(request);
        }

        public void AddMember(string listname, string firstname, string lastname, string company, string email)
        {
            var client = BuildClient();
            var request = new RestRequest("lists/{list}/members", Method.POST);
            request.AddParameter("list", $"{listname}@{domain}", ParameterType.UrlSegment);
            request.AddObject(new
            {
                subscribed = true,
                address = email,
                name = $"{firstname} {lastname}",
                vars = "{'company':" + company + "}",
                upsert = true
            });

            var response = client.Execute(request);
        }
    }
}
