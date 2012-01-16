using System;
using Catnap.Database;
using Catnap.Mapping;

namespace Catnap
{
    public class SessionFactory : ISessionFactory
    {
        private readonly IDbAdapter dbAdapter;
        private readonly string connectionString;
        private readonly IDomainMap domainMap;
        private readonly Func<ISessionCache> sessionCacheProvider;

        public SessionFactory(string connectionString, IDbAdapter dbAdapter, IDomainMap domainMap, Func<ISessionCache> sessionCacheProvider)
        {
            this.connectionString = connectionString;
            this.dbAdapter = dbAdapter;
            this.domainMap = domainMap;
            this.sessionCacheProvider = sessionCacheProvider;
        }

        public ISession Create()
        {
            return new Session(domainMap, connectionString, dbAdapter, sessionCacheProvider());
        }
    }
}