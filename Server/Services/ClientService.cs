namespace Server.Services
{
    using System;
    using System.Threading.Tasks;
    using IdentityServer3.Core.Models;
    using IdentityServer3.Core.Services;
    using Server.Repository;
    using Server.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class ClientService : IClientStore
    {

        private readonly IRepository<CustomClient> _repositoryCustomClient;
        private readonly IRepository<ClientSecret> _repositoryClientSecret;
        private readonly IRepository<AllowedScope> _repositoryAllowedScope;
        private readonly IRepository<RedirectUri> _repositoryRedirectUri;

        public ClientService()
        {
            _repositoryCustomClient = new GenericRepository<CustomClient, IdentityServerContext>();
            _repositoryClientSecret = new GenericRepository<ClientSecret, IdentityServerContext>();
            _repositoryAllowedScope = new GenericRepository<AllowedScope, IdentityServerContext>();
            _repositoryRedirectUri = new GenericRepository<RedirectUri, IdentityServerContext>();
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var entity = await _repositoryCustomClient.FindByAsync(clientId);

            if (entity != null)
            {
                var client = new Client();
                client.ClientName = entity.Name;
                client.ClientId = entity.Id;
                client.Flow = entity.Flow;
                client.AllowRememberConsent = entity.AllowRememberConsent;
                client.RequireConsent = entity.RequireConsent;
               
                client.AllowedScopes = entity.AllowedScopes.Select(x => x.Scope).ToList();
                client.AccessTokenType = entity.AccessTokenType;
                client.RefreshTokenUsage = entity.RefreshTokenUsage;

                if (entity.ClientSecrets.Count() > 0)
                {
                    client.ClientSecrets = entity.ClientSecrets.Select(x => new Secret(x.Secret)).ToList();
                }

                if (entity.RedirectUris.Count() > 0)
                {
                    client.RedirectUris = entity.RedirectUris.Select(x => x.Url).ToList();
                    client.PostLogoutRedirectUris = new List<string> { "http://localhost:52522/" };
                }
                
                return client;
            }

            return null;
        }
    }
}
