using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Web.Helpers;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(WebMvc.Startup))]

namespace WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:3333/identity",
                ClientId = "bd8333b52f504895a0023e35d76cbf66",
                //ClientSecret = "vOQc08agbEZbpSchlf6PpjK3thHMMIeeNi5pKbJqzEs=",
                //In the Scope we ask what to include
                Scope = "openid profile roles WebApi",
                RedirectUri = "http://localhost:52522/",
                PostLogoutRedirectUri = "http://localhost:52522/",
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false,

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        var id = n.AuthenticationTicket.Identity;
                        var sub = id.FindFirst(IdentityServer3.Core.Constants.ClaimTypes.Subject);
                        var roles = id.FindAll(IdentityServer3.Core.Constants.ClaimTypes.Role);

                        // create new identity and set name and role claim type
                        var nid = new ClaimsIdentity(id.AuthenticationType,
                                IdentityServer3.Core.Constants.ClaimTypes.Name, IdentityServer3.Core.Constants.ClaimTypes.Role);

                        nid.AddClaim(sub);
                        nid.AddClaims(roles);


                        // keep the id_token for logout
                        nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                        nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                        n.AuthenticationTicket = new AuthenticationTicket(nid, n.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = n =>
                    {
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }

                        return Task.FromResult(0);
                    }
                }
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityServer3.Core.Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
        }
    }
}
