namespace Server
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Server.Models;
    using System.Data.Entity;

    public class IdentityServerContext: IdentityDbContext<User>
    {
        public IdentityServerContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityServerContext Create()
        {
            return new IdentityServerContext();
        }

        public virtual IDbSet<CustomClient> CustomClients { get; set; }
        public virtual IDbSet<ClientSecret> ClientSecrets { get; set; }
        public virtual IDbSet<AllowedScope> AllowedScopes { get; set; }
        public virtual IDbSet<RedirectUri> RedirectUris { get; set; }
        public virtual IDbSet<CustomScope> CustomScopes { get; set; }
        public virtual IDbSet<DbScopeClaim> DbScopeClaims { get; set; }
    }
}
