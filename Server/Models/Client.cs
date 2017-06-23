namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using IdentityServer3.Core.Models;
    using System;
    using System.Collections.Generic;

    public class CustomClient
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Flows Flow { get; set; }
        public bool RequireConsent { get; set; }
        public bool AllowRememberConsent { get; set; }
        public AccessTokenType AccessTokenType { get; set; }
        public TokenUsage RefreshTokenUsage { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public int AccessTokenLifetime { get; set; }
        public virtual ICollection<ClientSecret> ClientSecrets { get; set; }
        public virtual ICollection<AllowedScope> AllowedScopes { get; set; }
        public virtual ICollection<RedirectUri> RedirectUris { get; set; }
    }

    public class ClientSecret
    {
        [Key]
        public string Id { get; set; }
        public string Secret { get; set; }
        public string HeaderValue { get; set; }
        public DateTimeOffset? Expiration { get; set; }
        public string CustomClientId { get; set; }
        public virtual CustomClient CustomClient { get; set; }
    }

    public class AllowedScope
    {
        [Key]
        public string Id { get; set; }
        public string Scope { get; set; }
        public string CustomClientId { get; set; }
        public virtual CustomClient CustomClient { get; set; }
    }

    public class RedirectUri
    {
        [Key]
        public string Id { get; set; }
        public string Url { get; set; }
        public string CustomClientId { get; set; }
        public virtual CustomClient CustomClient { get; set; }
    }
}
