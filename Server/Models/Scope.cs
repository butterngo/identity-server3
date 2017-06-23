namespace Server.Models
{
    using IdentityServer3.Core.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomScope
    {
        [Key]
        public string Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ScopeType Type { get; set; }
        public virtual ICollection<DbScopeClaim> DbScopeClaims { get; set; }
    }

    public class DbScopeClaim
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomScopeId { get; set; }
        public virtual CustomScope CustomScope { get; set; }
    }
}
