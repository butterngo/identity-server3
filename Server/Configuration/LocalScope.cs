namespace Server.Configuration
{
    using IdentityServer3.Core;
    using IdentityServer3.Core.Models;
    using System.Collections.Generic;
    
    public class LocalScope
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
         {
             new Scope
             {
                 Enabled = true,
                 Name = "roles",
                 Type = ScopeType.Identity,
                 Claims = new List<ScopeClaim>
                 {
                     new ScopeClaim("role")
                 }
             },
             new Scope
             {
                 Enabled = true,
                 DisplayName = "WebApi",
                 Name = "WebApi",
                 Description = "Secure WebApi",
                 Type = ScopeType.Resource,
                 Claims = new List<ScopeClaim>
                 {
                     new ScopeClaim(Constants.ClaimTypes.Name),
                     new ScopeClaim(Constants.ClaimTypes.Role),
                 }
             }
         };

            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}
