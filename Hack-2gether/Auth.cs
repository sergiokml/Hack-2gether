using Azure.Identity;

using Microsoft.Graph;

namespace Hack_2gether
{
    internal class Auth
    {
        public GraphServiceClient? TokenAuth()
        {
            string[] scopes = { "https://graph.microsoft.com/.default" };
            ClientSecretCredential clientSecretCredential =
                new(
                    "695cecd9-6b4e-4a18-b73f-6dcb6057a5ad", // TENANT
                    "bca832b1-32de-4866-9f93-9b0e4095cc18", // CLIENTE
                    "atW8Q~6JYsbfz8xFqzwlbGyfRfZRbjB_g43QPciW", //SECRET
                    new() { AuthorityHost = AzureAuthorityHosts.AzurePublicCloud }
                );
            GraphServiceClient graphClient = new(clientSecretCredential, scopes);
            return graphClient;
        }


    }
}
