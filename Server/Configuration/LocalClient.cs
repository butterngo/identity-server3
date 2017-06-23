namespace Server.Configuration
{
    using Common;
    using IdentityServer3.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LocalClient
    {
        public static IEnumerable<Client> Get()
        {
            var secret = "secret";

            //var header = Convert.ToBase64String(Encoding.ASCII.GetBytes("Client1" + ":" + secret));
            var encoding = Encoding.UTF8;
            var credentials = string.Format("{0}:{1}", "Client1", secret);

            var headerValue = Convert.ToBase64String(encoding.GetBytes(credentials));

            return new[]
            {
               new Client
               {
                   ClientName = "WebAPI Client",
                   ClientId = "Client1",
                   Flow = Flows.ResourceOwner,
                   ClientSecrets = new List<Secret>
                   {
                       new Secret(secret.Sha256())
                   },
                   AllowedScopes = new List<string>
                   {
                       "WebAPI"
                   },
                   AccessTokenType = AccessTokenType.Reference,
                   RefreshTokenUsage = TokenUsage.ReUse
               },
               //new Client
               //{
               //    Enabled = true,
               //    ClientName = "Identity Management Tool",
               //    ClientId = "IdentityManagementTool",
               //    Flow = Flows.AuthorizationCode,
               //    RequireConsent = true,
               //    AllowRememberConsent = true,
               //    RedirectUris = new List<string>
               //    {
               //        "http://localhost:55112/"
               //    },
               //    IdentityTokenLifetime = 360,
               //    AccessTokenLifetime = 3600,
               //    AllowedScopes = new List<string>()
               //    { "openid", "profile" , "roles", "WebAPI" }
               //},
           };
        }
    }
}
