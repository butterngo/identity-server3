namespace Server.Services
{
    using IdentityServer3.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IdentityServer3.Core.Models;
    using Server.Repository;
    using Server.Models;
    using System.Linq;
    using System.Data.Entity;

    public class ScopeService : IScopeStore
    {
        private readonly IRepository<CustomScope> _repositoryCustomScope;
        private readonly IRepository<DbScopeClaim> _repositoryDbScopeClaim;

        public ScopeService()
        {
            _repositoryCustomScope = new GenericRepository<CustomScope, IdentityServerContext>();
            _repositoryDbScopeClaim = new GenericRepository<DbScopeClaim, IdentityServerContext>();
        }

        public async Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            var entities = await _repositoryCustomScope.FindAll(x => scopeNames.Contains(x.Name)).ToListAsync();

            return MapData(entities);
        }

        public async Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            var entities = await _repositoryCustomScope.FindAll().ToListAsync();

            return MapData(entities);
        }

        private IEnumerable<Scope> MapData(IEnumerable<CustomScope> entities)
        {
            if (entities.Count() == 0) return null;

            var Scopes = entities.Select(x => new Scope
            {
                Enabled = x.Enabled,
                DisplayName = x.DisplayName,
                Name = x.Name,
                Type = x.Type,
                Claims = x.DbScopeClaims.Select(c => new ScopeClaim(c.Name)).ToList()
            }).ToList();

            Scopes.AddRange(StandardScopes.All);

            return Scopes;
        }
    }
}
