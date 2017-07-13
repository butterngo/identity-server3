namespace Server.Services
{
    using System.Threading.Tasks;
    using IdentityServer3.Core.Configuration;
    using IdentityServer3.Core.Models;
    using IdentityServer3.Core.Services;
    using IdentityServer3.Core.Services.Default;

    public class TokenService : DefaultTokenService, ITokenService
    {
        public TokenService(IdentityServerOptions options,
            IClaimsProvider claimsProvider,
            ITokenHandleStore tokenHandles,
            ITokenSigningService signingService,
            IEventService events,
            OwinEnvironmentService owinEnvironmentService)
            :base(options, claimsProvider, tokenHandles, signingService, events, owinEnvironmentService)
        {

        }

        public override async Task<Token> CreateAccessTokenAsync(TokenCreationRequest request)
        {
            var result = await base.CreateAccessTokenAsync(request);

            return result;
        }

        public override Task<string> CreateSecurityTokenAsync(Token token)
        {
            return base.CreateSecurityTokenAsync(token);
        }

        
    }
}
