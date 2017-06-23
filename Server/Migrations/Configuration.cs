namespace Server.Migrations
{
    using Common;
    using IdentityServer3.Core.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DbMigrationsConfiguration<Server.IdentityServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(Server.IdentityServerContext context)
        {
            PasswordHasher passwordHasher = new PasswordHasher();

            var user = context.Users.Where(u => u.UserName.Equals("admin")).FirstOrDefault();

            if (user == null)
            {
                user = new Models.User
                {
                    UserName = "admin",
                    Email = "ngovu.dl@gmail.com",
                    PasswordHash = passwordHasher.HashPassword("12345"),
                    SecurityStamp = passwordHasher.HashPassword("12345"),
                };

                context.Users.Add(user);

                context.SaveChanges();
            }

            CreateClient(context, "DemoWebApi", "WebApi", Flows.ResourceOwner, AccessTokenType.Jwt);
            CreateClient(context, "DemoWebMvc", "openid", Flows.Implicit, AccessTokenType.Jwt, true);
            CreateScope(context, "WebApi", "Secure WebApi", ScopeType.Resource);
            CreateScope(context, "roles", "Secure roles", ScopeType.Identity);
        }
        
        private void CreateClient(Server.IdentityServerContext context, string clientName, string scopeName,
            Flows Flow, AccessTokenType accessTokenType, bool isAddRedirectUri = false)
        {
            var client = context.CustomClients.Where(u => u.Name.Equals(clientName)).FirstOrDefault();

            if (client == null)
            {
                client = new Models.CustomClient
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Name = clientName,
                    Flow = Flow,
                    AccessTokenType = accessTokenType,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    IdentityTokenLifetime = 360,
                    AccessTokenLifetime = 3600
                };

                context.CustomClients.Add(client);

                context.SaveChanges();
            }

            var clientSecret = context.ClientSecrets.Where(u => u.CustomClientId.Equals(client.Id)).FirstOrDefault();

            if (clientSecret == null)
            {
                string secret = Guid.NewGuid().ToString();

                clientSecret = new Models.ClientSecret
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Secret = secret.Sha256(),
                    HeaderValue = Helper.ConvertBasicHeader(client.Id, secret),
                    CustomClientId = client.Id
                };

                context.ClientSecrets.Add(clientSecret);

                context.SaveChanges();
            }

            var allowedScope = context.AllowedScopes.Where(u => u.CustomClientId.Equals(client.Id)).FirstOrDefault();

            if (allowedScope == null)
            {
                allowedScope = new Models.AllowedScope
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Scope = scopeName,
                    CustomClientId = client.Id
                };

                context.AllowedScopes.Add(allowedScope);

                context.SaveChanges();
            }

            var redirectUri = context.RedirectUris.Where(u => u.CustomClientId.Equals(client.Id)).FirstOrDefault();

            if (redirectUri == null && isAddRedirectUri)
            {
                redirectUri = new Models.RedirectUri
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Url = "http://localhost:52522/",
                    CustomClientId = client.Id
                };

                context.RedirectUris.Add(redirectUri);

                context.SaveChanges();
            }

        }

        private void CreateScope(Server.IdentityServerContext context, string scopeName, string DisplayName, ScopeType scopeType)
        {
            var customScope = context.CustomScopes.Where(x => x.Name.Equals(scopeName)).FirstOrDefault();

            if (customScope == null)
            {
                customScope = new Models.CustomScope
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Enabled = true,
                    Name = scopeName,
                    DisplayName = DisplayName,
                    Type = scopeType
                };

                context.CustomScopes.Add(customScope);

                context.SaveChanges();
            }

            var dbScopeClaim = context.DbScopeClaims.Where(x => x.Name.Equals(IdentityServer3.Core.Constants.ClaimTypes.Name)).FirstOrDefault();

            if (dbScopeClaim == null)
            {
                dbScopeClaim = new Models.DbScopeClaim
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Name = IdentityServer3.Core.Constants.ClaimTypes.Name,
                    CustomScopeId = customScope.Id
                };

                context.DbScopeClaims.Add(dbScopeClaim);

                context.SaveChanges();
            }

            var dbScopeClaim1 = context.DbScopeClaims.Where(x => x.Name.Equals(IdentityServer3.Core.Constants.ClaimTypes.Role)).FirstOrDefault();

            if (dbScopeClaim1 == null)
            {
                dbScopeClaim1 = new Models.DbScopeClaim
                {
                    Id = Guid.NewGuid().ToString("n"),
                    Name = IdentityServer3.Core.Constants.ClaimTypes.Role,
                    CustomScopeId = customScope.Id
                };

                context.DbScopeClaims.Add(dbScopeClaim1);

                context.SaveChanges();
            }
        }
    }
}
